using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour , IMoney
{
    public int Money { get; set ; }

    private void Awake()
    {
        Money = SaveSystem.LoadDataInt(SaveSystem.MoneyData);
    }

    public void SaveMoney(int value)
    {
        SaveSystem.SaveData(value, SaveSystem.MoneyData);
    }

    public void LoadMoney(int value)
    {
        SaveSystem.LoadDataInt(SaveSystem.MoneyData);
    }

}
