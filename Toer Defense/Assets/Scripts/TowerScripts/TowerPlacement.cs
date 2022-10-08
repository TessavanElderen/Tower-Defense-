using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerPlacement : MonoBehaviour
{
    //Placement
    [Header("Placement Ref")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask placementCheckMask;

    public GameObject[] paths;

    [Header("Other Scripts")]
    [SerializeField] TowerShoot _towerShootScript;
    [SerializeField] UIManager _uiManager;
    public MoneySystem moneySystemScript;

    //Range
    [Header("Range Ref")]
    public GameObject rangeObject;
    public bool _isRangeGone;

    //Extra
    Vector3 worldPos;
    RaycastHit hitInfo;

    bool _isSelected = false;

    private void Start()
    {
        moneySystemScript = FindObjectOfType<MoneySystem>();
    }
    private void Update()
    {
        TowerPlacementRayCast();
    }

    private void TowerPlacementRayCast()
    {
        if (_isSelected) // als deze toren is geselecteerd dan word de raycast geactiveerd 
        {
            // Every sec that the tower in the world is a ray of the raycast will shoot a line in to worldspace
            _towerShootScript.enabled = false;
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out hitInfo, 100f, groundLayer))
            {
                _towerShootScript.enabled = true;
                worldPos = hitInfo.point;
            }
            if (Input.GetMouseButtonDown(0))
            {
                TowerPlacement towerPlacement = this;
                moneySystemScript.GetComponent<MoneySystem>().ButtonMoney(buttonAmount: 100);
                towerPlacement.enabled = false;
            }
            transform.position = new Vector3(worldPos.x, worldPos.y + (transform.localScale.y / 2), worldPos.z);
        }
    }

    //als ik de toren langs 1 van de paden haal word de range rood.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Path"))
        {
            rangeObject.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("Touch" + paths);
        }
    }

    //als ik de toren langs de map haal (Zonder de paden te raken) word de range groen.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Path"))
        {
            rangeObject.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("Not Touch" + paths);
        }
    }

    public void SelectTower(bool selectingTower)
    {
        _isSelected = selectingTower;
    }

}
