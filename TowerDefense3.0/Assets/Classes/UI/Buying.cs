using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buying : MonoBehaviour
{
    public Tower towerScript;
    [HideInInspector] GameObject currentTurret;

    public void Placement(GameObject turret)
    {
        currentTurret = Instantiate(turret, Vector3.up, Quaternion.identity); 
        currentTurret.GetComponent<Tower>().SelectTower(true);
    }
}
