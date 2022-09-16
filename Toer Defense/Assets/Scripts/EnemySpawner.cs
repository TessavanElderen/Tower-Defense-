using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Obj")]
    [SerializeField] GameObject myEnemy1; 

    [Header("WaveSpawner")]
    [SerializeField] int EnemyNum = 5;
    [SerializeField] int EnemyNumIncrease = 5;
    int toSpawn; 

    [Header("Spawning")]
    [SerializeField] float waitForEnemy = 1f;
    float spawnTimer;

    private void Start()
    {
        toSpawn = EnemyNum;
        spawnTimer = waitForEnemy; 
    }

    private void Update()
    {
        
        if (toSpawn > 0)
        {
            spawnTimer -= Time.deltaTime; 
            if (spawnTimer <= 0)
            {
                Instantiate(myEnemy1, gameObject.transform);
                toSpawn--;
                spawnTimer = waitForEnemy;
            }
        } 
        else if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            EnemyNum += EnemyNumIncrease;
            toSpawn = EnemyNum;
        }
    }
}
