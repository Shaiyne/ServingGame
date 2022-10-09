using SaveLoadSystem;
using Servingame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public DrinkStates _customerRequest;
    UpgradeData _upgradeData = new UpgradeData();

    private void OnEnable()
    {
        _upgradeData.TypeDrinkSize = SaveGameManager.CurrentSaveData.UpgradeData.TypeDrinkSize;
        _customerRequest = (DrinkStates)Random.Range(1, _upgradeData.TypeDrinkSize + 1); //Null var o yüzden +1
    }

}
