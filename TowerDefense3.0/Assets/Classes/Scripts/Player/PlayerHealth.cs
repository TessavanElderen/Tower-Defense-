using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
public class PlayerHealth : MonoBehaviour
{
    [Header("UI Refrences")]
    public GameObject lostPanel; 
    public TMP_Text healthText; 
    
    [Header("Health Refrences")]
    public int totalHealth = 100;

    [Header("Other Scripts")]
    public Spawner spawner;

    private void Start()
    {
        healthText.text = $"Lives {totalHealth} ";
        lostPanel.gameObject.SetActive(false);
    }

    public void TakeDamageHealth()
    {
        totalHealth --;
        healthText.text = $"Lives {totalHealth} ";
        if (totalHealth <= 0)
        {
            // Show Lost Scene
            lostPanel.gameObject.SetActive(true);
            
            // Scripts off
            spawner.enabled = false;
        }
    }
}
