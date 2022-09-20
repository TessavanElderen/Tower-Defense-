using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject currentTower;
    [SerializeField] GameObject towerPrefab;
    public void PlaceTower()
    {
        currentTower = Instantiate(towerPrefab, new Vector3(0,1,0), Quaternion.identity);
        currentTower.GetComponent<TowerMovement>().SelectTower(true); 
    }
}
