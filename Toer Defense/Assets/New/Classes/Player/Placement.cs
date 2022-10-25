using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class Placement : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera playerCamera;
    
    [Header("LayerMasks")]
    [SerializeField] private LayerMask placementColliderLayerMask;
    [SerializeField] private LayerMask placementCheckMask;

    [Header("Other Scripts")]
    [SerializeField] private PlayerStats playerStatisticts;

    // Private 
    private GameObject currentPlacingTower;
    
    private void Update()
    {
        if (currentPlacingTower != null)
        {
            Ray cameraRay = playerCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(cameraRay, out hitInfo, 100f, placementColliderLayerMask))
            {
                currentPlacingTower.transform.position = hitInfo.point;
            }

            if (Input.GetMouseButtonDown(1))
            {
                Destroy(currentPlacingTower);
                currentPlacingTower = null; 
                return;
            }

            if (Input.GetMouseButtonDown(0) && hitInfo.collider.gameObject != null)
            {
                if (!hitInfo.collider.gameObject.CompareTag("CantPlace"))
                {
                    BoxCollider towerCollider = currentPlacingTower.gameObject.GetComponent<BoxCollider>();
                    towerCollider.isTrigger = true;

                    Vector3 boxCenter = currentPlacingTower.gameObject.transform.position + towerCollider.center;
                    Vector3 halfExtens = towerCollider.size / 2;
                    if (!Physics.CheckBox(boxCenter, halfExtens, Quaternion.identity, placementCheckMask, QueryTriggerInteraction.Ignore))
                    {
                        TowerBehaviour currentTowerBehaviour = currentPlacingTower.GetComponent<TowerBehaviour>();

                        GameLoopManager.towerInGame.Add(currentTowerBehaviour);
                        playerStatisticts.AddMoney(-currentTowerBehaviour.summonCosts);
                        towerCollider.isTrigger = false;
                        currentPlacingTower = null;
                    }
                }
            }
        }
    }

    public void SetTowerToPlace(GameObject tower)
    {
        int towerSummonCost = tower.GetComponent<TowerBehaviour>().summonCosts;

        if (playerStatisticts.GetMoney() >= towerSummonCost)
        {
            currentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.Log("You Need More Money" + tower.name);
        }
    }
}
