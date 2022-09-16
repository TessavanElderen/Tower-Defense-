using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private string spawnName;
    [SerializeField] private List<EnemyWaves> waves;
    [SerializeField] private Vector3[] waveSpawnPoint;
    [SerializeField] private int currentWave = 0;
    [SerializeField] private int instanceNum = 1;

    private void Start()
    {
        StartCoroutine(StartWavesRoutine());
    }
    IEnumerator StartWavesRoutine()
    {
        while(currentWave < waves.Count)
        {
            StartCoroutine(SpawnEnemyRoutine());
            yield return new WaitForSeconds(5);
            GameObject[] activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in activeEnemies)
            {
                Destroy(enemy);
            }
            currentWave++;
            Debug.Log(currentWave);
            Debug.Log("Next Wave ");
        }
    }

    IEnumerator SpawnEnemyRoutine()
    {
        int currentSpawnPointIndex = 0;
        for (int i = 0; i < waves[currentWave].wavesSequence.Count ; i++)
        {
            GameObject obj = waves[currentWave].wavesSequence[i];
            GameObject currentEntity = Instantiate(obj, waveSpawnPoint[currentSpawnPointIndex], Quaternion.identity);
            currentEntity.name = spawnName + instanceNum;
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % waveSpawnPoint.Length;
            instanceNum++;
            yield return new WaitForSeconds(1);
            Debug.Log(instanceNum);
        }
    }
}
