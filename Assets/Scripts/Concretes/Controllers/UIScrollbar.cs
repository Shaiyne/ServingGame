using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollbar : MonoBehaviour
{
    [SerializeField] public Scrollbar scrollbar;

    private void OnEnable()
    {
        UISignals.Instance.onScrollbarFull += GetScrollbar;
    }
    public void FillScrollbar(float fillSpeed)
    {
        scrollbar.size += fillSpeed * Time.deltaTime;
    }

    public void GetScrollbar()
    {
        if (scrollbar.size == 1)
        {
            TraySignals.Instance.onCurrentScrollbarValue?.Invoke(scrollbar.size);
        }
        
    }

    public void ResetScrollbar()
    {
        scrollbar.size = 0;
    }

    public void ActivenesScrollbar(bool value)
    {
        scrollbar.gameObject.SetActive(value);
    }


}
