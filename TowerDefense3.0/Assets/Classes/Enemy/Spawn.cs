using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class Spawn : MonoBehaviour
{
    [Header("Scriptable Objects")] // Flags 
    public WaveScriptableObjects[] waves;

    [Header("Delays")]
    public float waveDelay = 1f; // Delay between Waves
    public float enemyDelay = 1f; // Delay between Enemies in the wave

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
                // Als de current kleiner is dan de currentWave met de waveInformation met de amountToSpawn
                if (currentEnemy < waves[currentWave].waveInformation[currentWaveInformation].amountToSpawn)
                {
                    // De enemyPrefab word met alle informatie Instantaite in de wave 
                    Instantiate(waves[currentWave].waveInformation[currentWaveInformation].enemyPrefab);

                    // er word een nieuwe enemy Instantaite 
                    currentEnemy++;

                    // timer Reset
                    enemyTimer = 0.0f;
                }
                else
                {
                    //Als de currentWaveInformation kleiner is dan de waves en de informatie lengte
                    if (currentWaveInformation + 1 < waves[currentWave].waveInformation.Length)
                    {
                        // Ga dan naar de volgende informatie is de wave
                        currentWaveInformation++;
                        // timer reset
                        waveTimer = 0.0f;
                    }
                    else
                    {
                        // als de currentwave kleiner is dan de wave length
                        if (currentWave + 1 < waves.Length)
                        {
                            // Ga dan naar de volgende in de lijst
                            currentWave++;
                        }
                    }
                }
            }
        }
    }
}

