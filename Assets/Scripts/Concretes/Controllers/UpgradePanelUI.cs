using SaveLoadSystem;
using Servingame.Controllers;
using Servingame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelUI : MonoBehaviour
{
    [SerializeField] private Text[] _upgradePanelMoneyText;
    UpgradeData _upgradeData1 = new UpgradeData();
    MoneyData _moneyData = new MoneyData();

    private void Awake()
    {
        _upgradeData1 = SaveGameManager.CurrentSaveData.UpgradeData;
        _moneyData = SaveGameManager.CurrentSaveData.MoneyData;
    }
    private void OnEnable()
    {
        //UpgradeSignals.Instance.onUpgradeCustomerButton = ShowSavedData;
        //UpgradeSignals.Instance.onUpgradeDrinkType = ShowSavedData;
        //UpgradeSignals.Instance.onUpgradeScrollbar = ShowSavedData;
    }
    private void Update()
    {
        ShowLoadData();
        UpgradePanelMoneyShow();
    }

    public void UpgradePanelMoneyShow()
    {
        _upgradePanelMoneyText[0].text = "" + _upgradeData1.CustomerCost;
        _upgradePanelMoneyText[1].text = "" + _upgradeData1.TypeDrinkCost;
        _upgradePanelMoneyText[2].text = "" + _upgradeData1.ScrollbarSpeedCost;
        _upgradePanelMoneyText[3].text = "" + _moneyData.Money;
    }

    private void ShowLoadData()
    {
        _moneyData = SaveGameManager.CurrentSaveData.MoneyData;
        _upgradeData1 = SaveGameManager.CurrentSaveData.UpgradeData;
    }
}
