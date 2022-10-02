using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour , IMoney
{
    public int Money { get; set ; }

    private void Awake()
    {
        Money = PlayerPrefs.GetInt("MoneyData");
    }

    public void SaveMoney(int value)
    {
        PlayerPrefs.SetInt("MoneyData", value);
    }

    public void EarningMoney(int value)
    {
        Money += value;
        SaveMoney(Money);
    }
}
