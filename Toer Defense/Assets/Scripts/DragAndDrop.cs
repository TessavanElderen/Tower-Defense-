using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class DragAndDrop : MonoBehaviour
{
    GameObject curTower;
    [SerializeField] Camera cam;
    [SerializeField] LayerMask groundlayer; 
    private void Update()
    {
        if(curTower != null) // prevent errors
        {
            // Every sec that the tower is in the world a ray of the raycast will shoot a line in to worldspace
            Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(cameraRay, out RaycastHit hitInfo, groundlayer))
            {
                curTower.transform.position = hitInfo.point; 
            }
            if (Input.GetMouseButtonDown(0))
            {
                curTower = null; 
            }

        }
    }
    // This function will make a tower every time you hit the button
    public void PlaceTower(GameObject tower)
    {
        curTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
    }
} 
