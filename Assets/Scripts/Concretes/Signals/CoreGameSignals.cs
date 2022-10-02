using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : Singleton<CoreGameSignals>
{
    public UnityAction onPlay = delegate { };
    public UnityAction onPause = delegate { };
    public UnityAction onQuit = delegate { };
    public UnityAction onGamePlay = delegate { };
    public UnityAction onGamePause = delegate { };
    public UnityAction onGameQuit = delegate { };
}
