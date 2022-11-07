using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
public class Buying : MonoBehaviour
{
    [HideInInspector] GameObject currentTurret;

    [Header("Other Scripts")]
    public Tower towerScript;

    [Header("Button Refrences")]
    public int buttonCostAmount; 

    private void Update()
    {
        ButtonInteractable();
    }

    private void ButtonInteractable()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = $"$ {buttonCostAmount}";

        
        if (GameObject.Find("MoneyText").GetComponent<Money>().displayMoney < buttonCostAmount)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
        
    }

    public void ButtonCosts(int costs)
    {
        GameObject.Find("MoneyText").GetComponent<Money>().displayMoney -= costs;
        Debug.Log($"ButtonAmount = {costs} and displayMoney = {GameObject.Find("Money")}");
    }

    public void Placement(GameObject turret)
    {
        currentTurret = Instantiate(turret, Vector3.up, Quaternion.identity); 
        currentTurret.GetComponent<Tower>().SelectTower(true, buttonCostAmount);
    }
}
