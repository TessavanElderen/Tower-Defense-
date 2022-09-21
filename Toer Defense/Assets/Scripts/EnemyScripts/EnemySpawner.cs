using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemySpawner : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text waveLeftText;
    [SerializeField] TMP_Text enemyLeftText;

    [Header("Obj")]
    [SerializeField] GameObject myEnemy;

    [Header("WaveSpawner")]
    [SerializeField] public int waveCounter = 1; 
    [SerializeField] public int EnemyNum = 5;
    [SerializeField] public int EnemyNumIncrease = 5;
    [SerializeField] public int toSpawn; 

    [Header("Spawning")]
    [SerializeField] public float waitForEnemy = 1f;
    [SerializeField] public float spawnTimer;

    [Header("EndGame")]
    [SerializeField] public int endLevel;


    private void Start()
    {
        toSpawn = EnemyNum;
        spawnTimer = waitForEnemy; 
    }

    private void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (toSpawn > 0)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                Instantiate(myEnemy, gameObject.transform);
                toSpawn--;

                spawnTimer = waitForEnemy;
            }
        }
        else if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            waveCounter++;
            EnemyNum += EnemyNumIncrease;
            toSpawn = EnemyNum;
        }
        waveLeftText.text = $"Wave: {waveCounter} / {endLevel}";
        enemyLeftText.text = $"Enemy: {GameObject.FindGameObjectsWithTag("Enemy").Length} / {EnemyNum}";
    }
}
