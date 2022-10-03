using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class MoneySystem : MonoBehaviour
{
    public TMP_Text moneyText;
    public int moneyCount = 150;
    public int waveMoneyCount = 80;

    private void Update()
    {
        DisplayMoney();
    }

    private void DisplayMoney()
    {
        moneyText.text = $"€ " + moneyCount;
    }
    public void AddMoney(int someGold)
    {
        moneyCount += someGold;
    }
}
