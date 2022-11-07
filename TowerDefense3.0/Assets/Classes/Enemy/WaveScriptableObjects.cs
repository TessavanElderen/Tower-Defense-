using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Flags
public struct WaveInfo
{
    //Enemies Informations

    public GameObject enemyPrefab;
    public int amountToSpawn; 
}

[CreateAssetMenu(fileName = "NewWave.Asset", menuName = "ScriptableObjects/Wave")]
public class WaveScriptableObjects : ScriptableObject
{
    public WaveInfo[] waveInformation; 
}