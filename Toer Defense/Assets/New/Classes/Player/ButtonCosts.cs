using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class ButtonCosts : MonoBehaviour
{
    [SerializeField] private int buttonAmount;

    private void Update()
    {
        ShowButtonText(); 
    }

    private void ShowButtonText()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = $"$ " + buttonAmount;
    }
}
