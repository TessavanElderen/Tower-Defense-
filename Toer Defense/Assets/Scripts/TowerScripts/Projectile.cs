using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDeleteTimer; 

    void Update()
    {
        Moveforward();
        BulletTimer();
    }

    private void Moveforward()
    {
        // De projectile dat word afgevuurd gaat met een bepaalde snelheid naar voren
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
    private void BulletTimer()
    {
        Destroy(gameObject, bulletDeleteTimer);
    }

    // Als de bullet de enemy raakt dan word de projectile destroyed. 
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
