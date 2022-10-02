using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
    UpgradeManager _upgradeManager;

    public Upgrade(UpgradeManager upgradeManager)
    {
        _upgradeManager = upgradeManager;
    }

    int _customers;
    int _typeOfDrink;
    float _scrollbarSpeed;
    int _customersCost;
    int _typeOfDrinkCost;
    int _scrollbarSpeedCost;

    public int Customers { get {return _customers; } set { _customers = Mathf.Clamp(value, 1, 4); } }
    public int TypeOfDrink { get { return _typeOfDrink; } set { _typeOfDrink = Mathf.Clamp(value, 2, 8); } }
    public float ScrollbarSpeed { get { return _scrollbarSpeed; } set { _scrollbarSpeed = Mathf.Clamp(value, 0.1f, 0.5f); } }

    public int CustomersCost { get { return _customersCost; } set { _customersCost = Mathf.Clamp(value, _customers*100, _customers*400); } }
    public int TypeOfDrinkCost { get { return _typeOfDrinkCost; } set { _typeOfDrinkCost = Mathf.Clamp(value, _typeOfDrink*100, _typeOfDrink*800); } }
    public int ScrollbarSpeedCost { get { return _scrollbarSpeedCost; } set { _scrollbarSpeedCost = Mathf.Clamp(value, (int)(_scrollbarSpeed*1000), (int)(_scrollbarSpeed*4000)); } }
}
