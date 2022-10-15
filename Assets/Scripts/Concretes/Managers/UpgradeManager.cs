using SaveLoadSystem;
using Servingame.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Servingame.Managers
{
    public class UpgradeManager : MonoBehaviour
    {
        UpgradeData _upgradeData = new UpgradeData();
        MoneyData _moneyData = new MoneyData();
        private void Awake()
        {
            UpgradeSignals.Instance.onUpgradePanelOpen += OnUpgradePanelOpen;
        }

        private void OnUpgradePanelOpen()
        {
            _upgradeData = SaveGameManager.CurrentSaveData.UpgradeData;
            _moneyData = SaveGameManager.CurrentSaveData.MoneyData;
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
            if (_upgradeData.CustomerSize == 4)
            {
                return;
            }
            else if (_upgradeData.CustomerCost <= _moneyData.Money)
            {
                UISignals.Instance.onMoneyChange?.Invoke(-_upgradeData.CustomerCost);
                _moneyData.Money -= _upgradeData.CustomerCost;
                _upgradeData.CustomerSize += 1;
                _upgradeData.CustomerCost = _upgradeData.CustomerSize * 100;
                SaveCurrentData();
            }

        }
        private void UpgradeDrink()
        {
            if (_upgradeData.TypeDrinkSize == 8)
            {
                return;
            }
            else if (_upgradeData.TypeDrinkCost <= _moneyData.Money)
            {
                UISignals.Instance.onMoneyChange?.Invoke(-_upgradeData.TypeDrinkCost);
                _moneyData.Money -= _upgradeData.TypeDrinkCost; 
                _upgradeData.TypeDrinkSize += 1;
                _upgradeData.TypeDrinkCost = _upgradeData.TypeDrinkSize * 100;
                SaveCurrentData();
            }


        }
        private void UpgradeSSpeed()
        {
            if (_upgradeData.ScrollbarSpeed == 0.5f)
            {
                return;
            }
            else if (_upgradeData.ScrollbarSpeedCost <= _moneyData.Money)
            {
                UISignals.Instance.onMoneyChange?.Invoke(-_upgradeData.ScrollbarSpeedCost);
                _moneyData.Money -= _upgradeData.ScrollbarSpeedCost;
                _upgradeData.ScrollbarSpeed += 0.1f;
                _upgradeData.ScrollbarSpeedCost = (int)(_upgradeData.ScrollbarSpeed * 1000);
                SaveCurrentData();
            }

        }
        private void SaveCurrentData()
        {
            SaveGameManager.CurrentSaveData.UpgradeData = _upgradeData;
            SaveGameManager.SaveGame();
        }
    }

}

