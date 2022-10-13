using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HRSignals : Singleton<HRSignals>
{
    public UnityAction onHireButton = delegate { };
    public UnityAction onHrPanelOpen = delegate { };
}
