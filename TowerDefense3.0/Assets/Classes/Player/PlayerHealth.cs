using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class PlayerHealth : MonoBehaviour
{
    public GameManager endingGame; 
    public TMP_Text healthText; 
    
    public int totalHealth = 100;

    private void Start()
    {
        healthText.text = $"Lives {totalHealth} ";
    }

    public void TakeDamageHealth()
    {
        totalHealth --;
        healthText.text = $"Lives {totalHealth} ";
        if (totalHealth <= 0)
        {
            // Show Lost Scene

            endingGame.LoadScene(0);
        }
    }
}
