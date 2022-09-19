using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject tower; 
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            target = other.gameObject;
            Debug.Log("1");
            Vector3 targetPostion = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            Debug.Log("2");
            tower.transform.LookAt(targetPostion);
            Debug.Log("3");
        }
    }
}
