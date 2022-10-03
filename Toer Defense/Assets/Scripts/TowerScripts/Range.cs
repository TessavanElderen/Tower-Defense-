using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    //kan deze niet private staan, als je het in de incpecrtor wil dan doe [SerializeField]
    public GameObject[] range;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            range = GameObject.FindGameObjectsWithTag("Path");
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
