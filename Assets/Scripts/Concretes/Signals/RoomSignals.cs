using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomSignals : Singleton<RoomSignals>
{
    public UnityAction<bool> onActivinessWall = delegate { };
}
