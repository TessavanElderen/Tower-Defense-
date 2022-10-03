using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //kan deze niet private staan, als je het in de incpecrtor wil dan doe [SerializeField]
    public float bulletSpeed;
    public float bulletDeleteTimer;

    //kan deze niet private staan, als je het in de incpecrtor wil dan doe [SerializeField]
    //deze kan je ook in een awake refrenceen.
    public EnemyHealth enemyHealthScript;

    //kan deze niet private staan, als je het in de incpecrtor wil dan doe [SerializeField]
    public int damageValue = 2;
    private void Start()
    {
        BulletTimer();
    }

    private void Update()
    {
        Moveforward();
    }

    private void Moveforward()
    {
        // De projectile dat word afgevuurd gaat met een bepaalde snelheid naar voren
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
    private void BulletTimer()
    {
        //Vernietig het gameObject na een aantal secondes. 
        Destroy(gameObject, bulletDeleteTimer);
    }

    // Als de bullet de enemy raakt dan word de projectile destroyed. 
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Pak het object (enemy). Pak ook het component EnemyHealth daarin pak ik de functie en roep die op.
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(amount: damageValue);

            //vernietig elke bullet als het object de enemy raakt.
            Destroy(gameObject);

            Debug.Log("Dead Enemy!!");
        }
    }
}
