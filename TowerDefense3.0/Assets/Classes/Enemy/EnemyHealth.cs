using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;

    [Header("Money")]
    public int damageCosts = 1;

    public void TakeDamage(int amount)
    {
        health -= amount; 
        if(health <= 0)
        {
            GameObject.Find("MoneyText").GetComponent<Money>().IncreaseMoney(amount: damageCosts);
            Destroy(this.gameObject); 
        }
    }
}
