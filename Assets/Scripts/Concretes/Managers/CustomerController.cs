using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public DrinkStates _customerRequest;

    //private void Awake()
    //{
    //    _customerRequest = (DrinkStates)Random.Range(1, UpgradeManager.Instance.TypeofDrink+1); //Null var o yüzden +1
    //}


    private void OnEnable()
    {
        _customerRequest = (DrinkStates)Random.Range(1, SaveSystem.LoadDataInt(SaveSystem.TypeDrinkData) + 1); //Null var o yüzden +1
    }

}
