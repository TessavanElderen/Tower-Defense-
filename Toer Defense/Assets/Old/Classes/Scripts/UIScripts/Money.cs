using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [Header("Values")]
    public int displayMoney = 0;
    
    private void Update()
    {
        DisplayMoney();
    }

    private void DisplayMoney()
    {
        GetComponent<TextMeshProUGUI>().text = $"$ " + displayMoney ;
    }

    public void DecreaseMoney(int amount)
    {
        displayMoney -= amount;
    }
}
