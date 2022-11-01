using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [HideInInspector] public Vector3 _worldPosition;

    [SerializeField] private LayerMask groundLayer;

    private bool _isSelected;

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

            if (Physics.Raycast(cameraRay, out hitInfo, Mathf.Infinity, groundLayer))
            {
                _worldPosition = hitInfo.point;
                GetComponent<Shooting>().enabled = false;
            }

            MouseInput(); 

            //Zorgt ervoor dat de tower niet naar de muis positie gaat.
            transform.position = new Vector3(_worldPosition.x, _worldPosition.y + (transform.localScale.y / 2), _worldPosition.z);
        }
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Tower>().enabled = true;
            GetComponent<Shooting>().enabled = true; 
            _isSelected = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
    }

    //Selecting the towers
    public void SelectTower(bool isSelecting)
    {
        _isSelected = isSelecting;
    }
}
