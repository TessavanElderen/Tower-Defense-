using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    private Test uiManager;
    void Start()
    {
        uiManager = GameObject.Find("GameManager").GetComponent<Test>();
    }
    private void Die()
    {
        uiManager.AddGold(10);

    }
}
