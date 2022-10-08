using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuySignals : Singleton<BuySignals>
{
    public UnityAction<GameObject> onBuyDesk = delegate { };
    public UnityAction<int> onCost = delegate { }; 
    public UnityAction<GameObject> onLoadDesk = delegate { };
    public UnityAction<GameObject> onSaveDesk = delegate { };
}
