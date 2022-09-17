using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject target;

    // Als ze in de range komen van de toren kan kijken ze naar de enemies. 
    // Als ze in de Ontrigger komen Find dan de target. 

    private void Start()
    {
        target = GameObject.Find("Enemy(Clone)"); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Vector3 targetPostion = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            transform.LookAt(targetPostion);
        }
    }
}
