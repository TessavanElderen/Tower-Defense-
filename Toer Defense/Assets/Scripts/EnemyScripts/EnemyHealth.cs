using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("References")]
    public int currentHealth = 20;

    //als de enemy health op 0 komt gaat hij dood. 
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth == 0)
        {
            Destroy(this.gameObject);
            Debug.Log(currentHealth);
        }
    }
}
