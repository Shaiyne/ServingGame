using Servingame.Abstracts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCommand
{
    public void HorizontalUpdate(TouchControls touchControlls) {
        if (touchControlls.Touch.TouchH.ReadValue<float>() != 0 || touchControlls.Touch.TouchV.ReadValue<float>() != 0)
        {
            InputSignals.Instance.onRunnerInputDragged?.Invoke(new RunnerInputParams()
            {
                XValue = touchControlls.Touch.TouchH.ReadValue<float>(),
                ZValue = touchControlls.Touch.TouchV.ReadValue<float>(),
            });
            InputSignals.Instance.onInputTaken?.Invoke();
        }
        else
        {
            if (!Input.GetMouseButton(0))
            {
                InputSignals.Instance.onInputReleased?.Invoke();
            }
        }
    }

}

