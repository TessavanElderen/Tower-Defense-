using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{

    public bool endLoop; 
    private void Start()
    {
        
    }

    IEnumerator GameLoop()
    {
        while (!endLoop)
        {
            //Spawn Enemies;

            //Spawn Towers; 

            //Move Enemies; 

            //Tick Towers; 

            //Apply Effects; 

            //Damage Enemies; 

            //Remove Enemies; 

            //Remove Towers; 

            yield return null; 
        }
    }
}
