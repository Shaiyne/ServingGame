
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveManager : MonoBehaviour 
{

    private void Awake() {
        SaveSystem.Init();
        IsDataExist();
    }
    private void OnEnable()
    {
        BuySignals.Instance.onSaveDesk += SaveDesk;
        UpgradeSignals.Instance.onGetMoney += SaveMoney;
    }
    private void SaveDesk(GameObject saveDesk)
    {

        SaveObject saveObject = new SaveObject
        {
            boughtAreaID = saveDesk.GetComponent<SaveableObjectInfo>().ID
        };
        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.SaveDesks(json);

    }

    public void SaveMoney(int value)
    {
        SaveSystem.SaveData(value,"save_Money");
    }
    private void IsDataExist()
    {
        if (SaveSystem.GetData(SaveSystem.CustomersData) == null)
        {
            SaveSystem.SaveData(1, SaveSystem.CustomersData);
            SaveSystem.SaveData(100, SaveSystem.CustomersCostData);
        }
        if (SaveSystem.GetData(SaveSystem.TypeDrinkData) == null)
        {
            SaveSystem.SaveData(3, SaveSystem.TypeDrinkData);
            SaveSystem.SaveData(300, SaveSystem.TypeDrinkCostData);
        }
        if (SaveSystem.GetData(SaveSystem.ScrollbarData) == null)
        {
            SaveSystem.SaveDataFloat(0.1f, SaveSystem.ScrollbarData);
            SaveSystem.SaveData(100, SaveSystem.ScrollbarCostData);
        }
    }

    private class SaveObject
    {
        public int boughtAreaID;
    }


}