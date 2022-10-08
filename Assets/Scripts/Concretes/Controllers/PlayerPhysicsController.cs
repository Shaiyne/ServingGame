using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("barrolLayer"))
        {
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.FillUp);
            TraySignals.Instance.onSetTrayPosition?.Invoke(TrayStates.FillingState);
            TraySignals.Instance.onTrayActive?.Invoke(true);
            UISignals.Instance.onActivenesScrollbar?.Invoke(true);
        }
        else if (other.gameObject.CompareTag("upgradeTag"))
        {
            UpgradeSignals.Instance.onUpgradePanelOpen?.Invoke();
            CoreGameSignals.Instance.onGamePause?.Invoke();
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("upgradeRoomLayer"))
        {
            UpgradeSignals.Instance.onActivinessWall?.Invoke(false);
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("barrolLayer"))
        {
            TraySignals.Instance.onGetColor?.Invoke(other.gameObject.name);
            UISignals.Instance.onScrollbarFillSpeed?.Invoke();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("buydeskLayer"))
        {
            BuySignals.Instance.onBuyDesk?.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("barrolLayer"))
        {
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.ServingRunning);
            TraySignals.Instance.onSetTrayPosition?.Invoke(TrayStates.ServingState);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("upgradeRoomLayer"))
        {
            UpgradeSignals.Instance.onActivinessWall?.Invoke(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("trashTag"))
        {
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.Running);
            TraySignals.Instance.onTrayActive?.Invoke(false);
            TraySignals.Instance.onResetDrinkState?.Invoke();
            UISignals.Instance.onResetScrollbar?.Invoke();
            UISignals.Instance.onActivenesScrollbar?.Invoke(false);
        }
        else if (collision.gameObject.CompareTag("customerTag"))
        {
            UISignals.Instance.onScrollbarFull?.Invoke();
            PlayerSignals.Instance.onCompareColor?.Invoke(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {

    }

}
