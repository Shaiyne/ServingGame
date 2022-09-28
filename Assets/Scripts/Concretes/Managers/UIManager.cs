using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int Money;

    [SerializeField] private Text MoneyText;

    private void Awake()
    {
        Money = PlayerPrefs.GetInt("MoneySave");
    }
    private void Update()
    {
        MoneyText.text = " " + PlayerPrefs.GetInt("MoneySave",Money);
    }

    private void OnEnable()
    {
        UISignals.Instance.onMoneyCollect += MoneyCollect;
    }
    private void OnDisable()
    {
        UISignals.Instance.onMoneyCollect -= MoneyCollect;
    }
    public void MoneyCollect(int earningMoney)
    {
        Money += earningMoney;
        SaveMoney(Money);
    }

    private void SaveMoney(int value)
    {
        PlayerPrefs.SetInt("MoneySave", value);
    }

    private void OnApplicationQuit()
    {
        //PlayerPrefs.SetInt("MoneySave", Money);
        //UISignals.Instance.onQuit += SaveMoney;
    }
}
