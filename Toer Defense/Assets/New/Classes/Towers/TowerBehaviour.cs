using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [Header("Tower: Refrences")]
    public LayerMask enemiesMask; 
    public Enemy target;
    public Transform towerPivot;

    [Header("Damage")]
    public float Damage;

    [Header("Shooting")]
    public float fireRate;

    [Header("Range")]
    public float range;

    [Header("Costs")]
    public int summonCosts = 100; 


    //private
    private float delay;
    private IDamageMethod currentDamageMethodClass; 


    void Start()
    {
        currentDamageMethodClass = GetComponent<IDamageMethod>(); 

        if(currentDamageMethodClass == null)
        {
            Debug.LogError("Towers: NO damage class on the given tower!!");
        }
        else
        {
            currentDamageMethodClass.Init(Damage, fireRate);
        }

        delay = 1 / fireRate; 
    }
  
    // Update tower of the gameloop state; 
    public void Tick()
    {
        currentDamageMethodClass.DamageTick(target); 
        if(target != null)
        {
            towerPivot.transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
        }
    }

    private void OnDrawGizmoSelected()
    {
        if(target != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, range);
            Gizmos.DrawLine(towerPivot.position, target.transform.position);
        }
    }
}
