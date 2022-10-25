using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Unity.Collections;
using UnityEngine.Jobs;
using Unity.Jobs;

public class GameLoopManager : MonoBehaviour
{
    [Header("Tower")]
    public static List<TowerBehaviour> towerInGame;

    [Header("Waypoint Refrences")]
    public static Vector3[] nodesPositions;
    public static float[] nodesDistances;

    //Private Queue
    private static Queue<ApplyEffectData> effectQueue;
    private static Queue<EnemyDamageData> _damageData;
    private static Queue<Enemy> enemiesToRemove;
    private static Queue<int> enemyIDsToSummon;

    private PlayerStats playerStatistics; 

    [Header("Extra Refrences")]
    public Transform nodeParent;
    public bool loopShouldEnd;

    private void Start()
    {
        playerStatistics = FindObjectOfType<PlayerStats>(); 

        towerInGame = new List<TowerBehaviour>();

        effectQueue = new Queue<ApplyEffectData>();
        _damageData = new Queue<EnemyDamageData>();
        enemyIDsToSummon = new Queue<int>();
        enemiesToRemove = new Queue<Enemy>();

        EntitySummoner.Init();

        nodesPositions = new Vector3[nodeParent.childCount];
        for (int i = 0; i < nodesPositions.Length; i++)
        {
            nodesPositions[i] = nodeParent.GetChild(i).position;
        }

        nodesDistances = new float[nodesPositions.Length - 1];
        for (int i = 0; i < nodesDistances.Length; i++)
        {
            nodesDistances[i] = Vector3.Distance(nodesPositions[i], nodesPositions[i + 1]);
        }

        StartCoroutine(GameLoop());
        InvokeRepeating("SummonTest", 0f, 1f);
    }

    private void SummonTest()
    {
        EnQueueEnemyIDToSummon(1);
    }

    IEnumerator GameLoop()
    {
        while (loopShouldEnd == false)
        {
            //Spawn Enemies;
            if (enemyIDsToSummon.Count > 0)
            {
                for (int i = 0; i < enemyIDsToSummon.Count; i++)
                {
                    EntitySummoner.SummonEnemy(enemyIDsToSummon.Dequeue());
                }
            }

            //Spawn Towers; 

            //Move Enemies; 
            NativeArray<Vector3> nodesToUse = new NativeArray<Vector3>(nodesPositions, Allocator.TempJob);
            NativeArray<float> enemySpeeds = new NativeArray<float>(EntitySummoner.enemiesInGame.Count, Allocator.TempJob);
            NativeArray<int> nodesIndices = new NativeArray<int>(EntitySummoner.enemiesInGame.Count, Allocator.TempJob);
            TransformAccessArray enemyAccess = new TransformAccessArray(EntitySummoner.enemiesInGameTransform.ToArray(), 2);

            for (int i = 0; i < EntitySummoner.enemiesInGame.Count; i++)
            {
                enemySpeeds[i] = EntitySummoner.enemiesInGame[i].speed;
                nodesIndices[i] = EntitySummoner.enemiesInGame[i].nodesIndex;
            }

            MoveEnemiesJob moveJob = new MoveEnemiesJob
            {
                nodesPos = nodesToUse,
                enemySpeed = enemySpeeds,
                nodesIndex = nodesIndices,
                deltaTime = Time.deltaTime
            };

            JobHandle moveJobHandle = moveJob.Schedule(enemyAccess);
            moveJobHandle.Complete();

            for (int i = 0; i < EntitySummoner.enemiesInGame.Count; i++)
            {
                EntitySummoner.enemiesInGame[i].nodesIndex = nodesIndices[i];
                if (EntitySummoner.enemiesInGame[i].nodesIndex == nodesPositions.Length)
                {
                    EnqueueEnemyToRemove(EntitySummoner.enemiesInGame[i]);
                }
            }

            enemySpeeds.Dispose();
            nodesIndices.Dispose();
            enemyAccess.Dispose();
            nodesToUse.Dispose();
            
            //Tick Towers; 
            foreach (TowerBehaviour tower in towerInGame)
            {
                    tower.target = TowerTargeting.GetTarget(tower, TowerTargeting.TargetType.first);
                    tower.Tick();
                    Debug.Log(tower.target);
            }

            //Apply Effects; 
            if (effectQueue.Count > 0)
            {
                for (int i = 0; i < effectQueue.Count; i++)
                {
                    ApplyEffectData currentDamageData = effectQueue.Dequeue();
                    Effect effectDuplicate = currentDamageData._enemyToAffect.activeEffects.Find(x => x._effectName == currentDamageData._effectToApply._effectName);
                    if (effectDuplicate == null)
                    {
                        currentDamageData._enemyToAffect.activeEffects.Add(currentDamageData._effectToApply);
                    }
                    else
                    {
                        effectDuplicate._expireTime = currentDamageData._effectToApply._expireTime; 
                    }
                }
            }

            //Tick the Enemies; 
            foreach(Enemy currentEnemy in EntitySummoner.enemiesInGame)
            {
                currentEnemy.Tick(); 
            }


            //Damage Enemies; 
            if (_damageData.Count > 0)
            {
                for (int i = 0; i < _damageData.Count; i++)
                {
                    EnemyDamageData currentDamageData = _damageData.Dequeue();
                    currentDamageData.targetedEnemy.health -= currentDamageData.totalDamage / currentDamageData._resistance;
                    playerStatistics.AddMoney((int)currentDamageData.totalDamage); 

                    if (currentDamageData.targetedEnemy.health <= 0f)
                    {
                        if (!enemiesToRemove.Contains(currentDamageData.targetedEnemy))
                        {
                            EnqueueEnemyToRemove(currentDamageData.targetedEnemy);
                        }
                    }
                }
            }

            //Remove Enemies; 
            if (enemiesToRemove.Count > 0)
            {
                for (int i = 0; i < enemiesToRemove.Count; i++)
                {
                    EntitySummoner.RemoveEnemy(enemiesToRemove.Dequeue());
                }
            }
            //Remove Towers; 

            yield return null;
        }
    }

    public static void EnQueueEffectToApply(ApplyEffectData effectData)
    {
        effectQueue.Enqueue(effectData);
    } 

    public static void EnQueueDamageData(EnemyDamageData damageData)
    {
        _damageData.Enqueue(damageData);
    }

    public static void EnQueueEnemyIDToSummon(int iD)
    {
        enemyIDsToSummon.Enqueue(iD);
    }

    public static void EnqueueEnemyToRemove(Enemy enemyToRemove)
    {
        enemiesToRemove.Enqueue(enemyToRemove);
    }
}

// Data we need for the effect for apply to the enemies
public class Effect
{
    public Effect(string effectName, float damageRate, float damage, float expireTime)
    {
        _expireTime = expireTime;
        _effectName = effectName;
        _damageRate = damageRate;
        _damage = damage;
    }

    public string _effectName;
    public float _damage;
    public float _expireTime;
    public float _damageRate;
    public float _damageDelay;

}

public struct ApplyEffectData
{
    public ApplyEffectData(Enemy enemyToAffect, Effect effectToApply)
    {
        _enemyToAffect = enemyToAffect;
        _effectToApply = effectToApply;
    }

    public Enemy _enemyToAffect;
    public Effect _effectToApply;
}

public struct EnemyDamageData
{
    public EnemyDamageData(Enemy target, float damage, float resistance)
    {
        targetedEnemy = target;
        totalDamage = damage;
        _resistance = resistance;
    }

    public Enemy targetedEnemy;
    public float totalDamage;
    public float _resistance;
}

// JOB SYSTEM
public struct MoveEnemiesJob : IJobParallelForTransform
{
    [NativeDisableParallelForRestriction]
    public NativeArray<Vector3> nodesPos;

    [NativeDisableParallelForRestriction]
    public NativeArray<float> enemySpeed;

    [NativeDisableParallelForRestriction]
    public NativeArray<int> nodesIndex;


    public float deltaTime;

    public void Execute(int index, TransformAccess transform)
    {
        if (nodesIndex[index] < nodesPos.Length)
        {
            Vector3 postitionToMoveTo = nodesPos[nodesIndex[index]];
            transform.position = Vector3.MoveTowards(transform.position, postitionToMoveTo, enemySpeed[index] * deltaTime);

            if (transform.position == postitionToMoveTo)
            {
                nodesIndex[index]++;
            }
        }
    }
}