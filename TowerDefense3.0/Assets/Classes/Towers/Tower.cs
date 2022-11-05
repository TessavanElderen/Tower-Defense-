using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [HideInInspector] public Vector3 _worldPosition;

    public int _towerCosts; 

    [SerializeField] private LayerMask groundLayer;

    private bool _isSelected;
    private bool _canPlace;

    private void Update()
    {
        RaycastDetection();
    }

    private void RaycastDetection()
    {
        if (_isSelected)
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            
            if (Physics.Raycast(cameraRay, out hitInfo, Mathf.Infinity, groundLayer) && !hitInfo.transform.CompareTag("Path"))
            {
                _worldPosition = hitInfo.point;
                _canPlace = true;

                GetComponent<Shooting>().enabled = false; 

                //Pakt de Tag van het pad && mag niet plaatsen op het pad
                if (hitInfo.transform.CompareTag("Path"))
                {
                    _canPlace = false;
                    Debug.Log("Placed A Tower");
                }
            }

            Mouse();

            //Zorgt ervoor dat de tower niet naar de muis positie gaat
            transform.position = new Vector3(_worldPosition.x, _worldPosition.y + (transform.localScale.y / 2), _worldPosition.z);

        }
    }

    // de geselecteerde turret aan de mouse Position
    private void Mouse()
    {
        if (Input.GetMouseButtonDown(0) && _canPlace)
        {
            GameObject.Find("MoneyText").GetComponent<Money>().DecreaseMoney(amount: _towerCosts);

            GetComponent<Shooting>().enabled = true; 
            GetComponent<Tower>().enabled = true;
            _isSelected = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
    }

    //Selecting the towers
    public void SelectTower(bool isSelecting, int costs)
    {
        _towerCosts = costs; 
        _isSelected = isSelecting;
    }
}
