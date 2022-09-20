using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] GameObject target;
    private GameObject tower;
    [SerializeField] int rotationSpeed = 5;
    //private float rotationA, rotationB; 
    private void Update()
    {
        LookingAtEnemy();
    }

    void LookingAtEnemy()
    {
        //transform.localRotation = Quaternion.Slerp(rotationA, rotationB, Time.deltaTime * rotationSpeed); 
    }
}
