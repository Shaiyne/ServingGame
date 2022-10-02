using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "LevelData", menuName = "Create Difficulty/Create New Difficulty", order = 1)]
public class UpgradeData : ScriptableObject
{
    [SerializeField] int _customers;
    [SerializeField] int _typeOfDrink;
    [SerializeField] float _scrollbarSpeedData;

    public int Customers => _customers;
    public int TypeOfDrink => _typeOfDrink;
    public float ScrollbarSpeedData => _scrollbarSpeedData;
}
