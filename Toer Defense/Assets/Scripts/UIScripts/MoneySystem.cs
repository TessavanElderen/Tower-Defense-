using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MoneySystem : MonoBehaviour
{
    [Header("Ref")]
    public TMP_Text moneyText;
    public int moneyCount = 150;
    public int waveMoneyCount = 80;

    [Header ("Canvas")]
    [SerializeField] Button towerButton; //list voor alleen de tower buttons. 
    [SerializeField] Canvas canvas;

    [Header("Other Scripts")]
    [SerializeField] EnemyHealth enemyHealthScript;


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

    public void ButtonMoney(int buttonAmount)
    {
        moneyCount -= buttonAmount;
        if (moneyCount <= buttonAmount)
        {
            towerButton.interactable = false;
        }
    }
}
