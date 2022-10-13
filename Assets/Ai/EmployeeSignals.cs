using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EmployeeSignals : Singleton<EmployeeSignals>
{
    public UnityAction onFill = delegate { };
    public UnityAction onMissionComplete = delegate { };
    public UnityAction<GameObject> onSetBool = delegate { };
    public UnityAction onCheckNewMission = delegate { };
}
