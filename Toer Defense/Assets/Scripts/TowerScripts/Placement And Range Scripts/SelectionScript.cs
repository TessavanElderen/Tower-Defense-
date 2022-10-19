using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour, ISelectable
{
    public bool _isSelected;

    //Selecting a tower (Show Range)
    public void Select()
    {
        _isSelected = true;
    }
    //Deselecting a tower (Don't Show Range)
    public void Deselect()
    {
        _isSelected = false;
    }
}
