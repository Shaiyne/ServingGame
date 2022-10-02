using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeSignals : Singleton<UpgradeSignals>
{
    public UnityAction onUpgradePanelOpen = delegate { };
    public UnityAction onUpgradeCustomerButton = delegate { };
    public UnityAction onUpgradeDrinkType= delegate { };
    public UnityAction onUpgradeScrollbar = delegate { };
}
