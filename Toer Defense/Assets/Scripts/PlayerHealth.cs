using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Gradient gradient;

    public int  health;

    GameManager gameManager;
    public int sceneIndexValue; 
    private void Start()
    {
        gradient = gameObject.GetComponent<Gradient>(); 
    }

    public void LoseHealth(int playerDamage)
    {
        health -= playerDamage;
        if (health == 0)
        {
            gameManager.GetComponent<GameManager>().LoadScene(sceneIndex: sceneIndexValue);
        }
    }

}
