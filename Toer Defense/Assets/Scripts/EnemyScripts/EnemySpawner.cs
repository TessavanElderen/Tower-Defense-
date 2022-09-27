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
    public TMP_Text waveLeftText;
    public TMP_Text enemyLeftText;

    public MoneySystem moneySystemScript;

    [Header("Obj")]
    public GameObject myEnemy;

    [Header("WaveSpawner")]
    public int waveCounter = 1; 
    public int EnemyNum = 5;
    public int EnemyNumIncrease = 5;
    public int toSpawn; 

    [Header("Spawning")]
    public float waitForEnemy = 1f;
    public float spawnTimer;

    [Header("EndGame")]
    public int endLevel;


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
            moneySystemScript.GetComponent<MoneySystem>().AddMoney(someGold: 80);
            EnemyNum += EnemyNumIncrease;
            toSpawn = EnemyNum;
        }
        waveLeftText.text = $"Wave: {waveCounter} / {endLevel}";
        enemyLeftText.text = $"Enemy: {GameObject.FindGameObjectsWithTag("Enemy").Length} / {EnemyNum}";
    }

   
}
