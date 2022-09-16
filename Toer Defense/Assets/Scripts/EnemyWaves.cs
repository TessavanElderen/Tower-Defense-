using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewWave.Asset", menuName = "ScriptableObjects/Wave")]
public class EnemyWaves : ScriptableObject
{
    [SerializeField] public List<GameObject> wavesSequence; // A List with diffent enemies
}
