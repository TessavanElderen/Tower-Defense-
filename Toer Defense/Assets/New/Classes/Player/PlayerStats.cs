using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int startingMoney;
    [SerializeField] private TextMeshProUGUI moneyDisplayText;
    private int currentMoney;

    private void Start()
    {
        currentMoney = startingMoney;
        moneyDisplayText.SetText($"$ {startingMoney}"); 
    }

    public void AddMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
        moneyDisplayText.SetText($"$ {currentMoney}");
    }

    public int GetMoney()
    {
        return currentMoney;
    }
}
