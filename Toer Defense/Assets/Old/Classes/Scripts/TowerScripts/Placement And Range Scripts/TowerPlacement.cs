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

    private void Update()
    {
        RaycastDetection();
    }

    private void RaycastDetection()
    {
        if (_isSelected)
        {
            RaycastHit _hitInfo;
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraRay, out _hitInfo, Mathf.Infinity, groundLayer, QueryTriggerInteraction.Ignore))
            {
                _worldPosition = _hitInfo.point;
            }

            if (Input.GetMouseButtonDown(0) && _canPlace)
            {
                //GameObject.Find("Money").GetComponent<Money>().DecreaseMoney(_towerCost);
                GetComponent<TowerPlacement>().enabled = true;
            }

            if (Input.GetMouseButtonDown(1))
            {
                Destroy(gameObject);
               
            }
            //Zorgt ervoor dat de tower niet naar de muis positie gaat.
            transform.position = new Vector3(_worldPosition.x, _worldPosition.y + (transform.localScale.y / 2), _worldPosition.z);
        }
    }


    //Selecting the towers
    public void SelectTower(bool isSelecting)
    {
        //_towerCost = costs;
        _isSelected = isSelecting;
    }
}
