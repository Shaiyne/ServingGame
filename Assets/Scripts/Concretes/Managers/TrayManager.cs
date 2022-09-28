using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayManager : MonoBehaviour
{
    [SerializeField] private Vector3 fillupTrayPosition;
    [SerializeField] private Vector3 servingTrayPosition;
    public DrinkStates drinkStates;
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
    }
    void DesubscribeEvents()
    {
        TraySignals.Instance.onSetTrayPosition -= SetTrayPosition;
        TraySignals.Instance.onTrayActive -= SetActiveTray;
        TraySignals.Instance.onGetColor -= ChangingDrinkColor;
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

    public void ChangingDrinkColor(string text)
    {
        drinkStates = _trayController.SetDrinkColor(text);
    }
    
    public void CompareRequest(DrinkStates drinkStates)
    {
        _trayController.CheckRequest(drinkStates);
    }
}
