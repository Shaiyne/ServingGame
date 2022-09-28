using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UISignals : Singleton<UISignals>
{
    public UnityAction<int> onMoneyCollect = delegate { };
    public UnityAction onPlay = delegate { };
    public UnityAction onPause = delegate { };
    public UnityAction onQuit = delegate { };
}
