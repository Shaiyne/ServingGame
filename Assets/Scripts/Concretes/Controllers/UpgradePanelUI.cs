using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelUI : MonoBehaviour
{
    [SerializeField] private Text[] _upgradePanelMoneyText;
    private void Update()
    {
        UpgradePanelMoneyShow();
    }

    public void UpgradePanelMoneyShow()
    {
        _upgradePanelMoneyText[0].text = "" + UpgradeManager.Instance.upgrade.CustomersCost;
        _upgradePanelMoneyText[1].text = "" + UpgradeManager.Instance.upgrade.TypeOfDrinkCost;
        _upgradePanelMoneyText[2].text = "" + UpgradeManager.Instance.upgrade.ScrollbarSpeedCost;
        _upgradePanelMoneyText[3].text = "" + PlayerPrefs.GetInt("MoneyData");
    }

}
