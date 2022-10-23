using SaveLoadSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour 
{
    MoneyData MoneyData = new MoneyData();

    private void Awake()
    {
        MoneyData.Money = LoadMoney();
        CoreGameSignals.Instance.onQuit += Quit;
        CoreGameSignals.Instance.onPause += Quit;
    }

    public void SaveMoney(int value)
    {
        MoneyData.Money = MoneyData.Money + value;
        SaveGameManager.CurrentSaveData.MoneyData = MoneyData;
    }

    public int LoadMoney()
    {
        MoneyData = SaveGameManager.CurrentSaveData.MoneyData;
        return MoneyData.Money;
    }

    public void Quit()
    {
        SaveGameManager.CurrentSaveData.MoneyData = MoneyData;
    } 
}