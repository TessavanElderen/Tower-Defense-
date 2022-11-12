using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
public class Spawner : MonoBehaviour
{
    [Header("UI Text")]
    public TMP_Text waveLeftText;
    public TMP_Text enemyLeftText;

    public GameObject winPanel; 

    [Header("Objects")]
    public GameObject myEnemy;

    [Header("WaveSpawner")]
    public int waveCounter = 1;
    public int EnemyNum = 5;
    public int EnemyNumIncrease = 5;
    private int _toSpawn;

    [Header("Spawning")]
    public float waitForEnemy = 1f;
    private float spawnTimer;

    [Header("EndGame")]
    public int endLevel;
    public GameManager endingGame;

    [Header("Other Scripts")]
    public Spawner spawner;

    private void Start()
    {
        _toSpawn = EnemyNum;
        spawnTimer = waitForEnemy;
        winPanel.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (_toSpawn > 0)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                Instantiate(myEnemy, gameObject.transform);
                _toSpawn--;

                spawnTimer = waitForEnemy;
            }
        }
        else if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            waveCounter++;
            EnemyNum += EnemyNumIncrease;
            _toSpawn = EnemyNum;

            if (waveCounter == endLevel)
            {
                // Show Win scene
                winPanel.gameObject.SetActive(true);
                spawner.enabled = false;
            }
        }
        
        waveLeftText.text = $"Wave {waveCounter} / {endLevel}";
        enemyLeftText.text = $"Enemy {GameObject.FindGameObjectsWithTag("Enemy").Length} / {EnemyNum}";
    }
}
