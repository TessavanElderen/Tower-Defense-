using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Lists")]
    public List<Effect> activeEffects; 

    [Header ("Health Enemy")]
    public float maxHealth;
    public float health;
    public float DamageResistance = 1f; 

    [Header("Speed Enemy")]
    public float speed;

    [Header("ID Enemy")]
    public int ID;

    [Header("Waypoint of the Enemy")]
    public int nodesIndex;

    [Header("Transforms")]
    public Transform rootPart; 

    public void Init()
    {
        activeEffects = new List<Effect>(); 

        health = maxHealth;
        transform.position = GameLoopManager.nodesPositions[0];
        nodesIndex = -1; 
    }

    public void Tick()
    {
        for (int i = 0; i < activeEffects.Count; i++)
        {
            if(activeEffects[i]._expireTime > 0)
            {
                if(activeEffects[i]._damageDelay > 0f)
                {
                    activeEffects[i]._expireTime -= Time.deltaTime;
                }
                else
                {
                    // Damage our self. 
                    GameLoopManager.EnQueueDamageData(new EnemyDamageData(this, activeEffects[i]._damage, 1f));
                    activeEffects[i]._damageDelay = 1f / activeEffects[i]._damageRate;
                }
                activeEffects[i]._expireTime -= Time.deltaTime;
            }
        }
        activeEffects.RemoveAll(x => x._expireTime <= 0f); 
    }
}
