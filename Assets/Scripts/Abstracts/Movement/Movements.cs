using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movements
{
    public void MovementControl(TouchControls touch)
    {
        InputSignals.Instance.onRunnerInputDragged?.Invoke(new RunnerInputParams()
        {
            XValue = touch.Touch.TouchH.ReadValue<float>(),
            ZValue = touch.Touch.TouchV.ReadValue<float>(),
        });
    }
    public void MovementInputRelease(PlayerAnimationStates playerAnimationStates)
    {
        if (!Input.GetMouseButton(0))
        {
            InputSignals.Instance.onAnimationInputState?.Invoke(playerAnimationStates);
        }
    }
}
