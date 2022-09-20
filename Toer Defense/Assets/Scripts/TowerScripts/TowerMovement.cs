using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class TowerMovement : MonoBehaviour
{
    public GameObject currentTower;
    Vector3 worldPos;
    bool isSelected = false;

    [SerializeField] LayerMask groundLayer; 
    private void Update()
    {
        TowerRayCast();
    }

    void TowerRayCast()
    {

        if (isSelected) // als deze toren is geselecteerd dan word de raycast geactiveerd 
        {
            // Every sec that the tower in the world is a ray of the raycast will shoot a line in to worldspace
            RaycastHit hit;
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out hit, Mathf.Infinity, groundLayer))
            {
                worldPos = hit.point;
            }
            if (Input.GetMouseButtonDown(0))
            {
                TowerMovement towerMovement = this;
                towerMovement.enabled = false;
            }
            transform.position = new Vector3(worldPos.x, worldPos.y + (transform.localScale.y / 2), worldPos.z);
        }
    }
    public void SelectTower(bool selectingTower)
    {
        isSelected = selectingTower; 
    }
    
} 
