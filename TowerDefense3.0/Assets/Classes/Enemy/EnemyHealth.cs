using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    // Health int 
    // Damage the enemy 
    public int health = 1; 

    public void TakeDamage(int amount)
    {
        health -= amount; 
        if(health >= 0)
        {
            Destroy(this.gameObject); 
        }
    }
}
