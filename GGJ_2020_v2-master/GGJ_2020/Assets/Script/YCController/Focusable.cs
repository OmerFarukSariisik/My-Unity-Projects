using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focusable : MonoBehaviour
{
    public FocusEvent focus;
    public bool isFocused = false;

    public void FocusEnter()
    {
        isFocused = true;
        transform.localScale *= 1.2f;
    }

    public void FocusExit()
    {
        isFocused = false;
        transform.localScale *= 0.83333f;
    }

    public void TriggerObj()
    {
        focus.TriggerEvent();
    }

}
