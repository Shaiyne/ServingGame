using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("barrolTag"))
        {
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.FillUp);
            TraySignals.Instance.onSetTrayPosition?.Invoke(TrayStates.FillingState);
            TraySignals.Instance.onTrayActive?.Invoke(true);
            TraySignals.Instance.onGetColor?.Invoke(other.gameObject.name); // Color string = name
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("barrolTag"))
        {
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.ServingRunning);
            TraySignals.Instance.onSetTrayPosition?.Invoke(TrayStates.ServingState);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("trashTag"))
        {
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.Running);
            TraySignals.Instance.onTrayActive?.Invoke(false);
        }
        else if (collision.gameObject.CompareTag("customerTag"))
        {
            PlayerSignals.Instance.onCompareColor?.Invoke(collision.gameObject.GetComponent<CustomerController>()._customerRequest);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("customerTag")) 
        {
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.Idle);
            TraySignals.Instance.onTrayActive?.Invoke(false);
        }

    }


}
