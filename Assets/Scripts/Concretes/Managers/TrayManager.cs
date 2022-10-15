using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrayManager : MonoBehaviour
{
    [SerializeField] private Vector3 fillupTrayPosition;
    [SerializeField] private Vector3 servingTrayPosition;
    public DrinkStates _drinkStates;
    TrayController _trayController;

    private void Awake()
    {
        _trayController = GetComponent<TrayController>();
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }
    private void OnDisable()
    {
        DesubscribeEvents();
    }

    void SubscribeEvents()
    {
        TraySignals.Instance.onSetTrayPosition += SetTrayPosition;
        TraySignals.Instance.onTrayActive += SetActiveTray;
        TraySignals.Instance.onGetColor += ChangingDrinkColor;
        TraySignals.Instance.onResetDrinkState += ResetDrinkState;
    }
    void DesubscribeEvents()
    {
        TraySignals.Instance.onSetTrayPosition -= SetTrayPosition;
        TraySignals.Instance.onTrayActive -= SetActiveTray;
        TraySignals.Instance.onGetColor -= ChangingDrinkColor;
        TraySignals.Instance.onResetDrinkState -= ResetDrinkState;
    }
    public void SetTrayPosition(TrayStates trayStates)
    {
        switch (trayStates)
        {
            case TrayStates.FillingState:
                transform.localPosition = fillupTrayPosition;
                break;
            case TrayStates.ServingState:
                transform.localPosition = servingTrayPosition;
                break;
        }
    }

    public void SetActiveTray(bool value)
    {
        _trayController.TrayActiveOrDeactive(value);
    }

    public void CompareRequest(GameObject customerObject)
    {
        _trayController.CheckRequest(customerObject);
    }

    public void ChangingDrinkColor(string barrolColor)
    {
         _trayController.SetDrinkColor(barrolColor);
    }

    public void ResetDrinkState()
    {
        _trayController.SetNullDrink();
    }
}
