using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySummoner : MonoBehaviour
{
    // checks which enemy are current alife; 
    public static List<Enemy> enemiesInGame;

    public static List<Transform> enemiesInGameTransform;

    // The int is the enemy ID && de GameObject is de refrence to the enemyprefab; 
    public static Dictionary<int, GameObject> enemyPrefabs;

    // The int is the enemy ID && de Queue == how many enemies in the pool; 
    public static Dictionary<int, Queue<Enemy>> enemyObjectPools;

    private static bool isInitailized;
 

    public static void Init()
    {
        if (!isInitailized)
        {
            enemyPrefabs = new Dictionary<int, GameObject>();
            enemyObjectPools = new Dictionary<int, Queue<Enemy>>();
            enemiesInGameTransform = new List<Transform>(); 
            enemiesInGame = new List<Enemy>();

            //Searce all the folders in the C:// untill you hit the Resources folder; 
            EnemySummoningData[] enemies = Resources.LoadAll<EnemySummoningData>("Enemies");

            //Go over any single enemyPrefabs and enemyObjectPool; 
            foreach (EnemySummoningData enemy in enemies)
            {
                enemyPrefabs.Add(enemy.enemyID, enemy.enemyPrefab);
                enemyObjectPools.Add(enemy.enemyID, new Queue<Enemy>());
            }
            isInitailized = true; 
        }
        else
        {
            Debug.Log("ENTITY SUMMONER: ALREADY INITAILIZED");
        }
    }

    // Summon a enemy;
    // Summon a enemy with the enemyID;
    public static Enemy SummonEnemy(int enemyID)
    {
        Enemy summonedEnemy = null;

        //If the enemyPrefabs contain the EnemyID ... 
        //If the enemyPrefabs DOES exist.. 
        if (enemyPrefabs.ContainsKey(enemyID))
        {
            Queue<Enemy> referencedQueue = enemyObjectPools[enemyID]; 

            // Check if there are any enemies are in the queue; 
            if(referencedQueue.Count > 0)
            {
                //Dequeue Enemy and initailize; 
                summonedEnemy = referencedQueue.Dequeue();
                summonedEnemy.Init();

                summonedEnemy.gameObject.SetActive(true);
            }
            else
            {
                //Instantaite new instance of the enemy and initailize; 
                GameObject newEnemy = Instantiate(enemyPrefabs[enemyID], GameLoopManager.nodesPositions[0], Quaternion.identity);
                summonedEnemy = newEnemy.GetComponent<Enemy>();
                summonedEnemy.Init();
            }
        }
        // If the enemyPrefab does not contain the enemyID than it will be nothing;
        // The enemy does not EXIST; 
        else
        {
            Debug.Log($"ENTITYSUMMONER: Enemy ID {enemyID} doesn't exist");
            return null; 
        }


        //Refrence to all enemies that are alife in the scene; 
        if (!enemiesInGame.Contains(summonedEnemy)) enemiesInGame.Add(summonedEnemy);
        if(!enemiesInGameTransform.Contains(summonedEnemy.transform)) enemiesInGameTransform.Add(summonedEnemy.transform);
        
        summonedEnemy.ID = enemyID;
        //if the code above is done then we will return the summoned enemy; 
        return summonedEnemy;
    } 

    public static void RemoveEnemy(Enemy enemyToRemove)
    {
        enemyObjectPools[enemyToRemove.ID].Enqueue(enemyToRemove);
        enemyToRemove.gameObject.SetActive(false);
        enemiesInGameTransform.Remove(enemyToRemove.transform);
        enemiesInGame.Remove(enemyToRemove); 
    }
}
