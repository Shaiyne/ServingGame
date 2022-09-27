using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayManager : MonoBehaviour
{
    [SerializeField]private Vector3 fillupTrayPosition;
    [SerializeField]private Vector3 servingTrayPosition;

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
    }
    void DesubscribeEvents()
    {
        TraySignals.Instance.onSetTrayPosition -= SetTrayPosition;
        TraySignals.Instance.onTrayActive -= SetActiveTray;
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
         transform.GetChild(0).gameObject.SetActive(value);
    }
}
