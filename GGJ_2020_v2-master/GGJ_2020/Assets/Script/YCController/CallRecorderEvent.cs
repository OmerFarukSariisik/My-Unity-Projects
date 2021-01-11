using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallRecorderEvent : FocusEvent
{
    public AnsweringMachine ansmec;

    override
    public void TriggerEvent()
    {
        ansmec.PlayTheMessage();
    }
}
