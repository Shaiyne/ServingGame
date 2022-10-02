using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UISignals : Singleton<UISignals>
{
    public UnityAction<int> onMoneyChange = delegate { };
    public UnityAction onPlay = delegate { };
    public UnityAction onPause = delegate { };
    public UnityAction onQuit = delegate { };
    public UnityAction onScrollbarFill = delegate { };
    public UnityAction onScrollbarFull = delegate { };
    public UnityAction onResetScrollbar = delegate { };
    public UnityAction<bool> onActivenesScrollbar = delegate { };
}
