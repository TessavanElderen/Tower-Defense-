using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int amountOfGold;
    void start()
    {
        amountOfGold = 0;
    }
    public void AddGold(int someGold)
    {
        amountOfGold += someGold;
    }
}

