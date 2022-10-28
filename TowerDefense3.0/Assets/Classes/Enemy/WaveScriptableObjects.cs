using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "NewWave.Asset", menuName = "ScriptableObjects/Wave")]
public class WaveScriptableObjects : ScriptableObject
{
    public List<GameObject> waves;
}
