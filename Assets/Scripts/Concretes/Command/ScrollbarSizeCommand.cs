using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarSizeCommand
{
    UIScrollbar _uiScrollbar;
    TrayController _trayController;
    float current=0;
    float result;


    public ScrollbarSizeCommand(ref UIScrollbar uiScrollbar, TrayController trayController)
    {
        _uiScrollbar = uiScrollbar;
        _trayController = trayController;
    }

    public float Execute()
    {
        return _uiScrollbar.scrollbar.size;
    }
    public float Execute2()
    {
        current +=  3f * Time.deltaTime;
        return current;
    }
}
