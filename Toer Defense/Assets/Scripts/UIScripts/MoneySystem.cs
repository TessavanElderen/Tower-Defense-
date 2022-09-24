using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class MoneySystem : MonoBehaviour
{
    public TMP_Text moneyText;
    public int moneyCount = 150;

    private int waveMoneyCount = 80; 

    void Update()
    {
        StartMoney();
    }
    void StartMoney()
    {
        moneyText.text = $"€ {moneyCount}";
    }

    public void WaveMoney(int gold)
    {
            moneyText.text = $"€ {moneyCount} + {waveMoneyCount}";
    }
}
