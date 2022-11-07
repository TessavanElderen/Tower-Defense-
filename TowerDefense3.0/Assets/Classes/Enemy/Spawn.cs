using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class Spawn : MonoBehaviour
{
    [Header("Scriptable Objects")] // Flags 
    public WaveScriptableObjects[] waveScripableObject;

    [Header("Delays")]
    public float waveDelay = 1.0f; // Delay between Waves
    public float enemyDelay = 1.0f; // Delay between Enemies in the wave

    //private
    private float waveTimer = 0.0f; 
    private float enemyTimer = 0.0f;

    private int currentWave = 0; // the Wave that is in the game
    private int currentEnemy = 0; // All enemies in the game

    private int currentWaveInformation = 0; // Information about the Enemy (Scripable Objects)
    
    private void Start()
    {
        waveTimer = waveDelay;
        enemyTimer = enemyDelay;
    }

    private void Update()
    {
        Spawning();
    }

    private void Spawning()
    {
        waveTimer += Time.deltaTime;

        // Als de wave Timer groter is dan de Delay van de Waves
        if(waveTimer > waveDelay)
        {
            enemyTimer += Time.deltaTime;

            // Als de enemy Timer groter is dan de Delay van de enemies
            if (enemyTimer > enemyDelay)
            {
                // Als de current enemy kleiner is dan de currentWave met de waveInformation en de amountToSpawn
                if (currentEnemy < waveScripableObject[currentWave].waveInformation[currentWaveInformation].amountToSpawn)
                {
                    Instantiate(waveScripableObject[currentWave].waveInformation[currentWaveInformation].enemyPrefab);
                    currentEnemy++;
                    enemyTimer = 0.0f;
                }
                else
                {
                    //Als de currentWaveInformation kleiner is dan de waves en de informatie lengte
                    if (currentWaveInformation + 1 < waveScripableObject[currentWave].waveInformation.Length)
                    {
                        currentWaveInformation++;
                        waveTimer = 0.0f;
                        Debug.Log("Wave: " + waveScripableObject.Length + "" + currentWave);
                    }
                    else
                    {
                        if (currentWave + 1 < waveScripableObject.Length)
                        {
                            currentWave++;
                            print("Next Wave");
                        }
                    }
                }
            }
        }
    }
}