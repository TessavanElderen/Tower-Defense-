using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BuyATower : MonoBehaviour
{
    public int buttonCostAmount = 150;

    private GameObject _curTower;
    private void Update()
    {
        ButtonInteractable();
    }

    private void ButtonInteractable()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = $"$ {buttonCostAmount}";
        /*
        if (GameObject.Find("Money").GetComponent<Money>().displayMoney < buttonCostAmount)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
        */
    }

    public void ButtonCosts(int costs)
    {
        GameObject.Find("Money").GetComponent<Money>().displayMoney -= costs;
        Debug.Log($"ButtonAmount = {costs} and displayMoney = {GameObject.Find("Money")}");
    }

    
    public void Placement(GameObject tower)
    {
        // tower word aangemaakt. 
        
        _curTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
        tower.GetComponent<TowerPlacement>().SelectTower(true);
        Debug.Log("A Tower");
    }
    
}
