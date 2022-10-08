using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : Singleton<UpgradeManager>
{
    //public Upgrade upgrade;

    private void Awake()
    {
        //upgrade = new Upgrade(this);
        //CreateDatas();
    }

    private void CreateDatas()
    {

        SaveSystem.SaveData(2, SaveSystem.TypeDrinkData);
        SaveSystem.SaveDataFloat(0.1f, SaveSystem.ScrollbarData);
        SaveSystem.SaveData(100, SaveSystem.CustomersCostData);
        SaveSystem.SaveData(200, SaveSystem.TypeDrinkCostData);
        SaveSystem.SaveData(100, SaveSystem.ScrollbarCostData);
        SaveSystem.SaveData(5000, SaveSystem.MoneyData);
    }
    private void OnEnable()
    {
        UpgradeSignals.Instance.onUpgradeCustomerButton += UpgradeCustomer;
        UpgradeSignals.Instance.onUpgradeDrinkType += UpgradeDrink;
        UpgradeSignals.Instance.onUpgradeScrollbar += UpgradeSSpeed;
    }
    private void OnDisable()
    {
        UpgradeSignals.Instance.onUpgradeCustomerButton -= UpgradeCustomer;
        UpgradeSignals.Instance.onUpgradeDrinkType -= UpgradeDrink;
        UpgradeSignals.Instance.onUpgradeScrollbar -= UpgradeSSpeed;
    }

    private void UpgradeCustomer()
    {
        if (SaveSystem.LoadDataInt(SaveSystem.CustomersData) == 4)
        {
            return;
        }
        else if (SaveSystem.LoadDataInt(SaveSystem.CustomersCostData) <= SaveSystem.LoadDataInt(SaveSystem.MoneyData))
        {
            UISignals.Instance.onMoneyChange?.Invoke(-SaveSystem.LoadDataInt(SaveSystem.CustomersCostData));
            SaveSystem.SaveData(SaveSystem.LoadDataInt(SaveSystem.CustomersData) + 1, SaveSystem.CustomersData);
            SaveSystem.SaveData(SaveSystem.LoadDataInt(SaveSystem.CustomersData) * 100, SaveSystem.CustomersCostData);
        }
        
    }
    private void UpgradeDrink()
    {
        if (SaveSystem.LoadDataInt(SaveSystem.TypeDrinkData)==8)
        {
            return;
        }
        else if(SaveSystem.LoadDataInt(SaveSystem.TypeDrinkCostData) <= SaveSystem.LoadDataInt(SaveSystem.MoneyData))
        {
            UISignals.Instance.onMoneyChange?.Invoke(-SaveSystem.LoadDataInt(SaveSystem.TypeDrinkCostData));
            SaveSystem.SaveData(SaveSystem.LoadDataInt(SaveSystem.TypeDrinkData)+1, SaveSystem.TypeDrinkData);
            SaveSystem.SaveData(SaveSystem.LoadDataInt(SaveSystem.TypeDrinkData) * 100, SaveSystem.TypeDrinkCostData);
        }


    }
    private void UpgradeSSpeed()
    {
        if (SaveSystem.LoadDataFloat(SaveSystem.TypeDrinkData) == 0.5f)
        {
            return;
        }
        else if(SaveSystem.LoadDataInt(SaveSystem.ScrollbarCostData) <= SaveSystem.LoadDataInt(SaveSystem.MoneyData))
        {
            UISignals.Instance.onMoneyChange?.Invoke(-SaveSystem.LoadDataInt(SaveSystem.ScrollbarCostData));
            SaveSystem.SaveDataFloat(SaveSystem.LoadDataFloat(SaveSystem.ScrollbarData) + 0.1f, SaveSystem.ScrollbarData);
            SaveSystem.SaveData((int)(SaveSystem.LoadDataFloat(SaveSystem.ScrollbarData) * 1000f), SaveSystem.ScrollbarCostData);
        }

    }


    //Oyun içinde olmuycak kod - silinicek
    public void ClearPanel()
    {
        SaveSystem.SaveData(1, SaveSystem.CustomersData);
        SaveSystem.SaveData(2, SaveSystem.TypeDrinkData);
        SaveSystem.SaveDataFloat(0.1f, SaveSystem.ScrollbarData);
        SaveSystem.SaveData(100, SaveSystem.CustomersCostData);
        SaveSystem.SaveData(2, SaveSystem.TypeDrinkCostData);
        SaveSystem.SaveData(100, SaveSystem.ScrollbarCostData);
        //upgrade.Customers = 0;
        //upgrade.TypeOfDrink = 0;
        //upgrade.ScrollbarSpeed = 0;
        //upgrade.CustomersCost = 0;
        //upgrade.TypeOfDrinkCost = 0;
        //upgrade.ScrollbarSpeedCost = 0;
        ////PlayerPrefs.SetInt("CustomerData", upgrade.Customers);
        ////PlayerPrefs.SetInt("TypeofdrinkData", upgrade.TypeOfDrink);
        ////PlayerPrefs.SetFloat("ScrollbarspeedData", upgrade.ScrollbarSpeed);
        //PlayerPrefs.SetInt("CustomerCostData", upgrade.CustomersCost);
        //PlayerPrefs.SetInt("TypeofdrinkCostData", upgrade.TypeOfDrinkCost);
        //PlayerPrefs.SetInt("ScrollbarspeedCostData", upgrade.ScrollbarSpeedCost);
    }

}
