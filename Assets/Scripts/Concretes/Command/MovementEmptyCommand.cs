using Servingame.Abstracts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEmptyCommand : Movements
{
    public void MovementEmptyCommandUpdate(TouchControls touchControls) {
        if (touchControls.Touch.TouchH.ReadValue<float>() != 0 || touchControls.Touch.TouchV.ReadValue<float>() != 0)
        {
            MovementControl(touchControls);
            //InputSignals.Instance.onInputTaken?.Invoke();
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.Running);
        }
        else
        {
            MovementInputRelease(PlayerAnimationStates.Idle);
        }
    }

}

