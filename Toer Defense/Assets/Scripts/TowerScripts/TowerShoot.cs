using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [Header("References Range"), Range(3f, 20.0f)]
    public float range; //diameter

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public float reloadSpeed;

    private GameObject target;
    private float reloadTimer = 0.0f;

    private void Start()
    {
        reloadTimer = reloadSpeed; 
    }

    private void Update()
    {
        //Heb ik een target?
        if (target)
        {
            if (EnemyInRange())
            {
                LookAtEnemy();
                ShootEnemy();
            }
            else
            {
                target = null; 
            }
        }
        else
        {
            FindNewEnemy();
        }
    }
    private void LookAtEnemy()
    {
        transform.LookAt(target.transform.position);
    }

    private void ShootEnemy()
    {
        reloadTimer += Time.deltaTime; 
        //de toren mag alleen schieten wanneer er genoeg tijd voorbij is gegaan (ook wel ge-reload)
        if(reloadTimer > reloadSpeed)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            reloadTimer = 0.0f;
        }
    }
    private bool EnemyInRange()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > range)
        {
            return false;
            
        }
        return true;
    }

    private void FindNewEnemy()
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, range);
        float minDistance = Mathf.Infinity;
        foreach (var obj in enemiesInRange)
        {
            //check de afstand van de toren tot de enemy
            float distance = Vector3.Distance(transform.position, obj.gameObject.transform.position);
           
            if (obj.CompareTag("Enemy"))
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                    //Als dat zo is dan is dat de dischtsbijzijnde enemy
                    target = obj.gameObject;
                }
            }
            //Is deze afstand wel of niet kleiner dan de vorige of Mathf.Infinity?
            //Zo nee de target wordt de dichtsbijzijndste enemy
        }
    }
}
