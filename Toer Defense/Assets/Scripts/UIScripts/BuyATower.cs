using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BuyATower : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TMP_Text buttonMoneyText;

    [Header("Button amount")]
    public int buttonMoneyAmount = 100;

    private void Update()
    {
        ButtonInteractable();
        DisplayButtonMoney();
    }

    public void AmountButton(int buttonAmount)
    {
        GameObject.Find("Money").GetComponent<Money>().displayMoney -= buttonAmount;
    }

    private void DisplayButtonMoney()
    {
        buttonMoneyText.text = ($"$ " + buttonMoneyAmount);
    }

    private void ButtonInteractable()
    {
        if (GameObject.Find("Money").GetComponent<Money>().displayMoney < buttonMoneyAmount)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
