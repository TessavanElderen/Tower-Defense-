using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class EnemySpawner : MonoBehaviour
{
    [Header("Text for Rounds and How Many enemies inGame")]
    public TMP_Text howManyWaves; 
    public TMP_Text howManyEnemies;
    public int addMoneyAfterWave; 

    [Header("Spawn")]
    [SerializeField] private string spawnName;

   // [SerializeField] private List<WaveScriptableObjects> wavesScripableObject;
    [SerializeField] private Vector3[] waveSpawnPoint;

    [SerializeField] private int currentWave = 0;
    [SerializeField] private int instanceNum = 1;

    [SerializeField] private float waitEnemies;
    [SerializeField] private int waitWave;

    [SerializeField] private int endGameWave; 
    /*

    private void Start()
    {
        StartCoroutine(StartWavesRoutine());
    }
    */
    /*
    IEnumerator StartWavesRoutine()
    {
        while (currentWave < wavesScripableObject.Count)
        {
            StartCoroutine(SpawnEnemyRoutine());
            yield return new WaitForSeconds(waitWave);
            GameObject[] activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in activeEnemies)
            {
                Destroy(enemy);
            }
            Debug.Log("Next Wave");
            currentWave++;
            howManyWaves.text = $"Wave: {currentWave} / {endGameWave}";
        }
    }
    */
  /*  IEnumerator SpawnEnemyRoutine()
    {
        int currentSpawnPointIndex = 0;

        for (int i = 0; i < wavesScripableObject[currentWave].waves.Count; i++)
        {
            GameObject obj = wavesScripableObject[currentWave].waves[i];
            GameObject currentEntity = Instantiate(obj, waveSpawnPoint[currentSpawnPointIndex], Quaternion.identity);
            currentEntity.name = spawnName + instanceNum;
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % waveSpawnPoint.Length;
            instanceNum++;
            yield return new WaitForSeconds(waitEnemies);
            howManyEnemies.text = $"Enemy: {GameObject.FindGameObjectsWithTag("Enemy").Length}";
        }
    }*/
}
