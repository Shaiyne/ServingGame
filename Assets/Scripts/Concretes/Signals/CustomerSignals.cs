using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomerSignals : Singleton<CustomerSignals>
{
    public UnityAction<GameObject> onDeactiveCustomer = delegate { };
    public UnityAction onDeskNull = delegate { };
}
