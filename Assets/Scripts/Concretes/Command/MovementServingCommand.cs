using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementServingCommand : Movements
{
    public void MovementServingCommandUpdate(TouchControls touchControls)
    {
        if (touchControls.Touch.TouchH.ReadValue<float>() != 0 || touchControls.Touch.TouchV.ReadValue<float>() != 0)
        {
            MovementControl(touchControls);
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.ServingRunning);

        }
        else
        {
            //if (!Input.GetMouseButton(0))
            //{
            //    InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.ServingIdle);
            //}
            MovementInputRelease(PlayerAnimationStates.ServingIdle);
        }
    }

    public void MovementFillUpCommandUpdate(TouchControls touchControls)
    {
        if (touchControls.Touch.TouchH.ReadValue<float>() == 0 || touchControls.Touch.TouchV.ReadValue<float>() == 0)
        {

            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.FillUp);
        }
        else
        {
            MovementControl(touchControls);
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.ServingRunning);
        }

    }
}
