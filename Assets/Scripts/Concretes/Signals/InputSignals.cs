using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputSignals : Singleton<InputSignals>
{
    public UnityAction onEnableInput = delegate { };
    public UnityAction onDisableInput = delegate { };
    public UnityAction<RunnerInputParams> onRunnerInputDragged = delegate { };
    public UnityAction<PlayerAnimationStates> onAnimationInputState = delegate { };
    public UnityAction onInputTaken = delegate { };
    public UnityAction onInputReleased = delegate { };
}
