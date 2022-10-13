using SaveLoadSystem;
using Servingame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    MoneyController _moneyController;
    UIScrollbar _uiScrollbar;
    [SerializeField] GameStates _gameStates; 
    [SerializeField] private Text MoneyText;
    [SerializeField] private GameObject _moneyUI;
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private GameObject colorMixedInformationPanel;
    UpgradeData upgradeData = new UpgradeData();
    [SerializeField] private GameObject _hrPanel;

    private void Awake()
    {
        _moneyController = GetComponent<MoneyController>();
        _gameStates = GameStates.CanMoveSituation;
        _uiScrollbar = GetComponentInChildren<UIScrollbar>();
    }
    private void OnEnable()
    {
        SubscribeEvent();
    }
    private void OnDisable()
    {
        DesubscribeEvent();
    }

    private void SubscribeEvent()
    {
        UISignals.Instance.onMoneyChange += ChangeMoney;
        UISignals.Instance.onPlay += ShowExistMoney;
        UISignals.Instance.onActivenesScrollbar += ActivenesScrollbar;
        UISignals.Instance.onScrollbarFillSpeed += ScrollbarFillSpeed;
        UISignals.Instance.onResetScrollbar += ResetScrollbar;
        CoreGameSignals.Instance.onPlay += onPlay;
        CoreGameSignals.Instance.onGamePlay += OnGamePlay;
        CoreGameSignals.Instance.onGamePause += OnGamePause;
        UpgradeSignals.Instance.onUpgradePanelOpen += OpenUpgradePanel;
        HRSignals.Instance.onHrPanelOpen += OpenHRPanel;
    }
    private void DesubscribeEvent()
    {
        UISignals.Instance.onMoneyChange -= ChangeMoney;
        UISignals.Instance.onPlay -= ShowExistMoney;
        UISignals.Instance.onActivenesScrollbar -= ActivenesScrollbar;
        UISignals.Instance.onScrollbarFillSpeed -= ScrollbarFillSpeed;
        UISignals.Instance.onResetScrollbar -= ResetScrollbar;
        CoreGameSignals.Instance.onPlay -= onPlay;
        CoreGameSignals.Instance.onGamePlay -= OnGamePlay;
        CoreGameSignals.Instance.onGamePause -= OnGamePause;
        UpgradeSignals.Instance.onUpgradePanelOpen -= OpenUpgradePanel;
        HRSignals.Instance.onHrPanelOpen -= OpenHRPanel;
    }

    private void onPlay()
    {
        ShowExistMoney();
        OnGamePlay();
    }

    private void OnPause()
    {
        OnGamePause();
    }
    private void OnGamePlay()
    {
        _moneyUI.gameObject.SetActive(true);
        ShowExistMoney();
    }
    private void OnGamePause()
    {
        _moneyUI.gameObject.SetActive(false);
    }

    #region MoneyCodes
    public void ChangeMoney(int value)
    {
        _moneyController.SaveMoney(value);
    }

    private void ShowExistMoney()
    {
        MoneyText.text = " " + _moneyController.LoadMoney();
    }

    #endregion

    #region ScrollbarCodes

    private void ActivenesScrollbar(bool value)
    {
        _uiScrollbar.ActivenesScrollbar(value);
    }
    private void ScrollbarFillSpeed()
    {
        upgradeData = SaveGameManager.CurrentSaveData.UpgradeData;
        _uiScrollbar.FillScrollbar(upgradeData.ScrollbarSpeed);
    }

    private void IsScrollbarFull()
    {
        _uiScrollbar.GetScrollbar();
    }

    private void ResetScrollbar()
    {
        _uiScrollbar.ResetScrollbar();
    }
    #endregion

    #region UpgradeCodes
    private void OpenUpgradePanel()
    {
        _upgradePanel.SetActive(true);
    }
    public void CloseUpgradePanel()
    {
        _upgradePanel.SetActive(false);
        CoreGameSignals.Instance.onGamePlay?.Invoke();
    }

    public void UpgradeCustomerButton()
    {
        UpgradeSignals.Instance.onUpgradeCustomerButton?.Invoke();
    }
    public void UpgradeDrinkTypeButton()
    {
        UpgradeSignals.Instance.onUpgradeDrinkType?.Invoke();
    }
    public void UpgradeScrollbarButton()
    {
        UpgradeSignals.Instance.onUpgradeScrollbar?.Invoke();
    }
    #endregion

    #region InformationPanelCodes
    public void ColorMixInformationPanel(bool value)
    {
        if (value) CoreGameSignals.Instance.onGamePause?.Invoke();
        else CoreGameSignals.Instance.onGamePlay?.Invoke();
        colorMixedInformationPanel.SetActive(value);
    }
    #endregion

    #region HRCodes
    public void OpenHRPanel()
    {
        _hrPanel.SetActive(true);
    }
    public void CloseHRPanel()
    {
        _hrPanel.SetActive(false);
        CoreGameSignals.Instance.onGamePlay?.Invoke();
    }
    public void HRHireButton()
    {
        HRSignals.Instance.onHireButton?.Invoke();
    }
    #endregion
}
