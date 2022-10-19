using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BuyATower : MonoBehaviour
{
    [Header("Button amount")]
    [SerializeField] int buttonCostAmount;

    [Header("GameObject")]
    public GameObject towerPrefab;

    private void Update()
    {
        ButtonInteractable();
    }

    private void ButtonInteractable()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = $"$ " + buttonCostAmount;

        if (GameObject.Find("Money").GetComponentInChildren<Money>().displayMoney < buttonCostAmount)
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
        GameObject.Find("Money").GetComponent<Money>().displayMoney -= costs;
        Debug.Log($"ButtonAmount = {costs} and displayMoney = {GameObject.Find("Money")}");
    }

    public void Placement()
    {
        // tower word aangemaakt. 
        GameObject tower = Instantiate(towerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
        tower.GetComponent<TowerPlacement>().SelectTower(true, buttonCostAmount);
        Debug.Log("A Tower");
    }
}
