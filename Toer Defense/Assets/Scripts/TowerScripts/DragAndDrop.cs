using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class DragAndDrop : MonoBehaviour
{
    public GameObject curTower;
    [SerializeField] Camera cam;
    [SerializeField] LayerMask groundlayer;

    Vector3 worldPos; 
    private void Update()
    {
        TowerRayCast();
    }

    void TowerRayCast()
    {

        if (curTower != null) // prevent errors
        {
            // Every sec that the tower in the world is a ray of the raycast will shoot a line in to worldspace
            groundlayer = 1 << 8;  
            RaycastHit hit;
            Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out hit, 100f, groundlayer))
            {
                worldPos = hit.point;
            }
            if (Input.GetMouseButtonDown(0))
            {
                curTower = null;
            }
            transform.position = new Vector3(worldPos.x, worldPos.y + (transform.localScale.y / 2), worldPos.z);
        }
    }
} 
