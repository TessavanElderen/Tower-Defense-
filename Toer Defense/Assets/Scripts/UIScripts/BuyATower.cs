using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuyATower : MonoBehaviour
{
    // Ik wil dat je aan het begin van de game een getal ziet hoe veel de toren gaat kosten     
    public TMP_Text buttonMoneyText;
    public int buttonMoneyAmount = 100;

    private void Update()
    {
        DisplayButtonMoney();
    }
    private void DisplayButtonMoney()
    {
        buttonMoneyText.text = ($"€: " + buttonMoneyAmount);
    }
}
