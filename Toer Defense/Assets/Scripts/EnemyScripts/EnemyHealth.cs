using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("References")]
    public int health; 
    public int damage; 

    [Header("Objects")]
    public GameObject enemyObject;
    public GameObject bulletObject;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            health--;
            Destroy(gameObject);
        }
        Debug.Log(health);
    }
}
