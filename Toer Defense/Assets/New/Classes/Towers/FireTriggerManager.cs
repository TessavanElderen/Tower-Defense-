using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTriggerManager : MonoBehaviour
{
    [SerializeField] private FlameThrowerDamage baseClass;

    [HideInInspector] public float enemyOnFire; 

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Effect flameEffect = new Effect("Fire", baseClass.fireRate, baseClass.damage, enemyOnFire);
            ApplyEffectData effectData = new ApplyEffectData(EntitySummoner.enemiesTransformPairs[other.transform.parent], flameEffect);
            GameLoopManager.EnQueueEffectToApply(effectData); 
        }
    }*/
}
