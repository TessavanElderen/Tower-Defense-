using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Create EnemyData")]
public class EnemySummoningData : ScriptableObject
{
    public GameObject enemyPrefab;
    public int enemyID; 
}
