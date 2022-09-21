using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{

    //De toren mag niet op de path geplaatst worden. 
    //Als je toren je pad raakt dan word die een andere kleur. 
    [SerializeField] GameObject placingTower;
    [SerializeField] LayerMask pathLayer;


    /*private void OnTriggerEnter(Collider other)
    {
        if ()
        {

        }
    }*/
}
