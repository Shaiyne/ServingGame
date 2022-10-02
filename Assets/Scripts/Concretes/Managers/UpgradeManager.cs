using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : Singleton<UpgradeManager>
{
    public Upgrade upgrade;

    private void Awake()
    {
        upgrade = new Upgrade(this);
        SetAll();
        //PlayerPrefs.SetInt("MoneyData", 5000);
    }
    private void Update()
    {
        Debug.Log("Customer : " + upgrade.Customers);
        Debug.Log("Drink : " + upgrade.TypeOfDrink);
        Debug.Log("Scrollbar : " + upgrade.ScrollbarSpeed);
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
    private void SetAll()
    {
        upgrade.Customers = PlayerPrefs.GetInt("CustomerData");
        upgrade.TypeOfDrink = PlayerPrefs.GetInt("TypeofdrinkData");
        upgrade.ScrollbarSpeed = PlayerPrefs.GetFloat("ScrollbarspeedData");
        upgrade.CustomersCost = PlayerPrefs.GetInt("CustomerCostData");
        upgrade.TypeOfDrinkCost = PlayerPrefs.GetInt("TypeofdrinkCostData");
        upgrade.ScrollbarSpeedCost = PlayerPrefs.GetInt("ScrollbarspeedCostData");
    }

    private void UpgradeCustomer()
    {
        if (upgrade.Customers == 4)
        {
            return;
        }
        else if (upgrade.CustomersCost <= PlayerPrefs.GetInt("MoneyData"))
        {
            UISignals.Instance.onMoneyChange?.Invoke(-upgrade.CustomersCost);
            upgrade.Customers += 1;
            upgrade.CustomersCost = upgrade.Customers * 100;
            PlayerPrefs.SetInt("CustomerData", upgrade.Customers);
            PlayerPrefs.SetInt("CustomerCostData", upgrade.CustomersCost);
        }

    }
    private void UpgradeDrink()
    {
        if (upgrade.TypeOfDrink==8)
        {
            return;
        }
        else if(upgrade.TypeOfDrinkCost <= PlayerPrefs.GetInt("MoneyData"))
        {
            UISignals.Instance.onMoneyChange?.Invoke(-upgrade.TypeOfDrinkCost);
            upgrade.TypeOfDrink += 1;
            upgrade.TypeOfDrinkCost = upgrade.TypeOfDrink * 100;
            PlayerPrefs.SetInt("TypeofdrinkData", upgrade.TypeOfDrink);
            PlayerPrefs.SetInt("TypeofdrinkCostData", upgrade.TypeOfDrinkCost);
        }


    }
    private void UpgradeSSpeed()
    {
        if (upgrade.ScrollbarSpeed==0.5f)
        {
            return;
        }
        else if(upgrade.ScrollbarSpeedCost <= PlayerPrefs.GetInt("MoneyData"))
        {
            UISignals.Instance.onMoneyChange?.Invoke(-upgrade.ScrollbarSpeedCost);
            upgrade.ScrollbarSpeed += 0.1f;
            upgrade.ScrollbarSpeedCost = (int)(upgrade.ScrollbarSpeed * 1000);
            PlayerPrefs.SetFloat("ScrollbarspeedData", upgrade.ScrollbarSpeed);
            PlayerPrefs.SetInt("ScrollbarspeedCostData", upgrade.ScrollbarSpeedCost);
        }

    }


    //Oyun içinde olmuycak kod - silinicek
    public void ClearPanel()
    {
        upgrade.Customers = 0;
        upgrade.TypeOfDrink = 0;
        upgrade.ScrollbarSpeed = 0;
        upgrade.CustomersCost = 0;
        upgrade.TypeOfDrinkCost = 0;
        upgrade.ScrollbarSpeedCost = 0;
        PlayerPrefs.SetInt("CustomerData", upgrade.Customers);
        PlayerPrefs.SetInt("TypeofdrinkData", upgrade.TypeOfDrink);
        PlayerPrefs.SetFloat("ScrollbarspeedData", upgrade.ScrollbarSpeed);
        PlayerPrefs.SetInt("CustomerCostData", upgrade.CustomersCost);
        PlayerPrefs.SetInt("TypeofdrinkCostData", upgrade.TypeOfDrinkCost);
        PlayerPrefs.SetInt("ScrollbarspeedCostData", upgrade.ScrollbarSpeedCost);
    }

    //public void ChooseUpgrade(int upgradeCost,int upgrade,string dataName,int value)
    //{
    //    UISignals.Instance.onMoneyCollect?.Invoke(-upgradeCost);
    //    upgrade += 1;
    //    upgradeCost = upgrade * value;
    //    PlayerPrefs.SetInt(dataName, upgrade);
    //    PlayerPrefs.SetInt(dataName, upgradeCost);
    //}
}
