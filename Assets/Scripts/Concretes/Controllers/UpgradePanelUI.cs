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
        _upgradePanelMoneyText[0].text = "" + SaveSystem.LoadDataInt(SaveSystem.CustomersCostData);
        _upgradePanelMoneyText[1].text = "" + SaveSystem.LoadDataInt(SaveSystem.TypeDrinkCostData);
        _upgradePanelMoneyText[2].text = "" + SaveSystem.LoadDataInt(SaveSystem.ScrollbarCostData);
        _upgradePanelMoneyText[3].text = "" + SaveSystem.LoadDataInt(SaveSystem.MoneyData);
    }

}
