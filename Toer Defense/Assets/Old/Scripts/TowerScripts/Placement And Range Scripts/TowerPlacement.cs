using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerPlacement : MonoBehaviour
{
    // Detecteren van de toren
    [SerializeField] LayerMask groundLayer;

    //private
    private int _towerCost;

    private bool _canPlace;
    private bool _isSelected;
    
    private Vector3 _worldPosition;
    private RaycastHit _hitInfo;



    private void Update()
    {
        RaycastDetection();
    }

    private void RaycastDetection()
    {
        if (_isSelected)
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out _hitInfo, 100, groundLayer))
            {
                _worldPosition = _hitInfo.point;
            }
            if (Input.GetMouseButtonDown(0) && _canPlace)
            {
                GameObject.Find("Money").GetComponent<Money>().DecreaseMoney(_towerCost);
                GetComponent<TowerPlacement>().enabled = false;
            }
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(gameObject);
            }
            //Zorgt ervoor dat de tower niet naar de muis positie gaat.
            transform.position = new Vector3(_worldPosition.x, _worldPosition.y + (transform.localScale.y / 2), _worldPosition.z);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Path") && !_canPlace)
        {
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Ground") && _canPlace)
        {
            gameObject.SetActive(true);
        }
    }*/



    //Selecting the towers
    public void SelectTower(bool isSelecting, int costs)
    {
        _towerCost = costs;
        _isSelected = isSelecting;
    }
}
