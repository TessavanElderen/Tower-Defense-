using Unity.Collections;
using UnityEngine;
using Unity.Jobs;

public class TowerTargeting
{
    public enum TargetType
    {
        first,
        last,
        close
    };

    public static Enemy GetTarget(TowerBehaviour currentTower, TargetType targetMethod)
    {
        Collider[] EnemiesInRange = Physics.OverlapSphere(currentTower.transform.position, currentTower.range, currentTower.enemiesMask);

        NativeArray<EnemyData> enemiesToCalculate = new NativeArray<EnemyData>(EnemiesInRange.Length, Allocator.TempJob);
        NativeArray<Vector3> nodesPostion = new NativeArray<Vector3>(GameLoopManager.nodesPositions, Allocator.TempJob);
        NativeArray<float> nodesDistances = new NativeArray<float>(GameLoopManager.nodesDistances, Allocator.TempJob);
        NativeArray<int> enemyToIndex = new NativeArray<int>(new int[] { -1 }, Allocator.TempJob);

        int enemyIndexToReturn = -1;

        for (int i = 0; i < enemiesToCalculate.Length; i++)
        {
            Enemy currentEnemy = EnemiesInRange[i].transform.parent.GetComponent<Enemy>();
            int enemyIndexInList = EntitySummoner.enemiesInGame.FindIndex(x => x == currentEnemy);

            enemiesToCalculate[i] = new EnemyData(currentEnemy.transform.position, currentEnemy.nodesIndex, currentEnemy.health, enemyIndexInList);
        }

        SearchForEnemy enemySearchJob = new SearchForEnemy
        {
            _enemiesToCalculate = enemiesToCalculate,
            _nodesDistances = nodesDistances,
            _nodesPostion = nodesPostion,
            _enemyToIndex = enemyToIndex,
            targetingType = (int)targetMethod,
            towerPosition = currentTower.transform.position
        };

        switch ((int)targetMethod)
        {
            case 0: //First
                enemySearchJob.CompareValue = Mathf.Infinity;
                break;
            case 1: //Last
                enemySearchJob.CompareValue = Mathf.NegativeInfinity;
                break;
            case 2: //Close
                goto case 0;

            case 3: //Strong
                goto case 1; 
            case 4: // Weak
                goto case 0;  
        }

        JobHandle dependency = new JobHandle();
        JobHandle searchJobHandle = enemySearchJob.Schedule(enemiesToCalculate.Length, dependency);
        searchJobHandle.Complete();

        if (enemyToIndex[0] != -1)
        {
            enemyIndexToReturn = enemiesToCalculate[enemyToIndex[0]].enemyIndex;

            enemiesToCalculate.Dispose();
            nodesPostion.Dispose();
            nodesDistances.Dispose();
            enemyToIndex.Dispose();

            return EntitySummoner.enemiesInGame[enemyIndexToReturn];
        }

        enemiesToCalculate.Dispose();
        nodesPostion.Dispose();
        nodesDistances.Dispose();
        enemyToIndex.Dispose();
        return null;
    }

    struct EnemyData
    {
        public Vector3 enemyPosition;
        public int enemyIndex;
        public int nodesIndex;
        public float health;

        public EnemyData(Vector3 position, int wayIndex, float hp, int eIndex)
        {
            enemyPosition = position;
            nodesIndex = wayIndex;
            enemyIndex = eIndex;
            health = hp;
        }
    }

    struct SearchForEnemy : IJobFor
    {
        [NativeDisableParallelForRestriction]
        public NativeArray<EnemyData> _enemiesToCalculate;

        [NativeDisableParallelForRestriction]
        public NativeArray<Vector3> _nodesPostion;

        [NativeDisableParallelForRestriction]
        public NativeArray<float> _nodesDistances;

        [NativeDisableParallelForRestriction]
        public NativeArray<int> _enemyToIndex;

        public Vector3 towerPosition;
        public float CompareValue;
        public int targetingType;

        public void Execute(int index)
        {
            float currentEnemyDistanceToEnd = 0;
            float distanceToEnemy = 0;

            switch (targetingType)
            {
                case 0: // First

                    currentEnemyDistanceToEnd = GetDistanceToEnd(_enemiesToCalculate[index]);

                    if (currentEnemyDistanceToEnd < CompareValue)
                    {
                        _enemyToIndex[0] = index;
                        CompareValue = currentEnemyDistanceToEnd;
                    }

                    break;

                case 1: // Last

                    currentEnemyDistanceToEnd = GetDistanceToEnd(_enemiesToCalculate[index]);

                    if (currentEnemyDistanceToEnd > CompareValue)
                    {
                        _enemyToIndex[0] = index;
                        CompareValue = currentEnemyDistanceToEnd;
                    }

                    break;

                case 2: // Close

                    distanceToEnemy = Vector3.Distance(towerPosition, _enemiesToCalculate[index].enemyPosition);

                    if (distanceToEnemy > CompareValue)
                    {
                        _enemyToIndex[0] = index;
                        CompareValue = distanceToEnemy;
                    }

                    break;

                case 3: // Strong

                    if (_enemiesToCalculate[index].health > CompareValue)
                    {
                        _enemyToIndex[0] = index;
                        CompareValue = _enemiesToCalculate[index].health;
                    }
                    break;

                case 4: // weak

                    if (_enemiesToCalculate[index].health < CompareValue)
                    {
                        _enemyToIndex[0] = index;
                        CompareValue = _enemiesToCalculate[index].health;
                    }
                    break; 
            }
        }

        private float GetDistanceToEnd(EnemyData enemyToEvaluate)
        {
            float finalDistance = Vector3.Distance(enemyToEvaluate.enemyPosition, _nodesPostion[enemyToEvaluate.nodesIndex]);
            for (int i = enemyToEvaluate.nodesIndex; i < _nodesPostion.Length; i++)
            {
                finalDistance += _nodesDistances[i];
            }

            return finalDistance;
        }
    }
}
