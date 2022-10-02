using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TraySignals : Singleton<TraySignals>
{
    public UnityAction<TrayStates> onSetTrayPosition = delegate { };
    public UnityAction<bool> onTrayActive = delegate { };
    public UnityAction<string> onGetColor = delegate { };
    public UnityAction denemeTrayEvent = delegate { };
    public UnityAction onResetDrinkState = delegate { };

}
