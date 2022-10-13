using SaveLoadSystem;
using Servingame.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HRPanelUI : MonoBehaviour
{
    [SerializeField] private Text[] _upgradePanelMoneyText;
    HRData _hrData = new HRData();
    MoneyData _moneyData = new MoneyData();

    private void Awake()
    {
        _hrData = SaveGameManager.CurrentSaveData.HRData;
        _moneyData = SaveGameManager.CurrentSaveData.MoneyData;
    }

    private void Update()
    {
        ShowLoadData();
        UpgradePanelMoneyShow();
    }

    public void UpgradePanelMoneyShow()
    {
        _upgradePanelMoneyText[0].text = "" + _hrData.EmployeeBuyCost;
        _upgradePanelMoneyText[1].text = "" + _moneyData.Money;
    }

    private void ShowLoadData()
    {
        _moneyData = SaveGameManager.CurrentSaveData.MoneyData;
        _hrData = SaveGameManager.CurrentSaveData.HRData;
    }
}
