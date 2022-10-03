using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class TowerMovement : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer; 

    Vector3 worldPos;

    bool _isSelected = false;
    private GameObject _currentTower;
    [SerializeField] TowerShoot _towerShootScript;
    [SerializeField] UIManager _uiManager; 

    private void Update()
    {
        TowerRayCast();
    }

    private void TowerRayCast()
    {
        if (_isSelected) // als deze toren is geselecteerd dan word de raycast geactiveerd 
        {
            // Every sec that the tower in the world is a ray of the raycast will shoot a line in to worldspace
            _towerShootScript.enabled = false;
            RaycastHit hit;
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out hit, Mathf.Infinity, groundLayer))
            {
                _towerShootScript.enabled = true; 
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
        _isSelected = selectingTower; 
    }

    //Als de enemy op het pad omdat zie je geen enemy meer. 
    //Als de enemy weer van het pad gaat dan zie je de enemy weer.

    // Als de Tower op het pad komt. 
    // Movement script (Placement) word dan uitgeschakeld. 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Path"))
        {
            //_uiManager.GetComponent<UIManager>().Placement(false); 
        }
        else
        {
            //_uiManager.Placement(true);
        }
    }
}
