using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class UIManager : MonoBehaviour
{
    //GameObjecten
    [Header("GameObject")]
    public GameObject currentTower;
    public GameObject towerPrefab;

    public void Placement(bool isPlacing)
    {
        currentTower = Instantiate(towerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
        currentTower.GetComponent<TowerPlacement>().SelectTower(true);
        Debug.Log("A Tower On Mouse");
    }

   
}
