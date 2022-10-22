using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastOefening : MonoBehaviour
{
    public LayerMask waterLayer;
    public GameObject sphere; 
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 worldPos;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if(Physics.Raycast(camRay,out hit,Mathf.Infinity, waterLayer))
        {
            worldPos = hit.point;
            Debug.Log(hit.transform.name);
            sphere.GetComponent<Renderer>().material.color = Random.ColorHSV();
            Debug.Log("hit");
        }
        else
        {
            Debug.Log("No hit");
        }
    }
}
