using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private void Start()
    {
        
    }
    // This function will make a tower every time you hit the button
    public void PlaceTower(GameObject tower)
    {
        curTower = Instantiate(tower, new Vector3(0, 1, 0), Quaternion.identity);
    }
}
