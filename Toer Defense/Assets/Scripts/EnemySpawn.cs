using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] private float spawnTimer = 1f;

    [SerializeField] List<GameObject> enemy = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyPrefab.AddComponent(enemy.transform);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform); // Pak een enemy prefab +1
            yield return new WaitForSeconds(spawnTimer); // Wacht seconds voordat er nog een spawnt
        }
    }
}
