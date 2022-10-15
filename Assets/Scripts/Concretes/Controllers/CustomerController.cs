using SaveLoadSystem;
using Servingame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public DrinkStates _customerRequest;
    UpgradeData _upgradeData = new UpgradeData();
    public bool customerBool;
    [SerializeField] CustomerRequestUI _customerRequestUI;

    private void OnEnable()
    {
        customerBool = false;
        FindObjectOfType<AudioManager>().Play("OrderSound");
        _upgradeData.TypeDrinkSize = SaveGameManager.CurrentSaveData.UpgradeData.TypeDrinkSize;
        _customerRequest = (DrinkStates)Random.Range(1, _upgradeData.TypeDrinkSize + 1); //DrinkState ilk deðer de Null var o yüzden +1
        _customerRequestUI.SetRequestUI(_customerRequest);
    }


}
