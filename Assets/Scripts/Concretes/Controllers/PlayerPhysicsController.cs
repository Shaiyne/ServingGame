using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("barrolTag"))
        {
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.FillUp);
            TraySignals.Instance.onSetTrayPosition?.Invoke(TrayStates.FillingState);
            TraySignals.Instance.onTrayActive?.Invoke(true);
        }
        if (collision.gameObject.CompareTag("trashTag"))
        {
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.Running);
            TraySignals.Instance.onTrayActive?.Invoke(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("barrolTag"))
        {
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.ServingRunning);
            TraySignals.Instance.onSetTrayPosition?.Invoke(TrayStates.ServingState);

        }

    }
}
