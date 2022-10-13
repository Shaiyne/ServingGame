using SaveLoadSystem;
using Servingame.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRManager : MonoBehaviour
{
    [SerializeField] GameObject[] employees;
    MoneyData _moneyData = new MoneyData();
    HRData _hRData = new HRData();

    private void Awake()
    {

    }
    private void Start()
    {
        _hRData = SaveGameManager.CurrentSaveData.HRData;
        if (_hRData.EmployeeID.Count != 0)
        {
            LoadEmployee(_hRData.EmployeeID.Count);
        }
    }
    private void OnEnable()
    {
        HRSignals.Instance.onHireButton += HireEmployee;
    }

    private void HireEmployee()
    {
        _hRData = SaveGameManager.CurrentSaveData.HRData;
        _moneyData = SaveGameManager.CurrentSaveData.MoneyData;
        if (_hRData.EmployeeID != null)
        {
            if (_hRData.EmployeeID.Count == 4)
            {
                Debug.Log("aasdas");
                return;
            }
            else if (_hRData.EmployeeBuyCost <= _moneyData.Money)
            {
                UISignals.Instance.onMoneyChange?.Invoke(-_hRData.EmployeeBuyCost);
                _moneyData.Money -= _hRData.EmployeeBuyCost;
                _hRData.EmployeeID.Add(employees[_hRData.EmployeeID.Count].GetComponent<Employee>().employeeID);
                _hRData.EmployeeBuyCost += 300;
                SaveEmployee();
                SetActiveEmployeer();
            }
        }

    }


    private void LoadEmployee(int count)
    {
        for (int i = 0; i < count; i++)
        {
            employees[i].SetActive(true);
            employees[i].transform.position = new Vector3(employees[i].GetComponent<Employee>().employeeID+1, 0, 0);
        }

    }

    private void SaveEmployee()
    {
        SaveGameManager.CurrentSaveData.HRData = _hRData;
        SaveGameManager.CurrentSaveData.MoneyData = _moneyData;
        SaveGameManager.SaveGame();
    }

    private void SetActiveEmployeer()
    {
        employees[_hRData.EmployeeID.Count-1].SetActive(true);
        employees[_hRData.EmployeeID.Count - 1].transform.position = new Vector3(employees[_hRData.EmployeeID.Count-1].GetComponent<Employee>().employeeID + 1, 0, 0);
    }
}

