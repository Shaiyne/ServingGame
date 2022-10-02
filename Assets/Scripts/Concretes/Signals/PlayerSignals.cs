using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerSignals : Singleton<PlayerSignals>
{
    public UnityAction<GameObject> onCompareColor = delegate { };
}
