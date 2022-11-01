using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] GameObject target;


    private bool _isShooting;

    private void Update()
    {
        ShootAtTarget();
    }

    private void ShootAtTarget()
    {

        if (Physics.Raycast(transform.position, transform.forward))
        {
            Debug.Log($"Raycast: Hit {target}");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, target.transform.position);
        Gizmos.color = Color.green;
    }
}
