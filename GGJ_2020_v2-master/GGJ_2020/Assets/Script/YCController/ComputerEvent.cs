using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerEvent : FocusEvent
{
    public LevelController lc;

    override
    public void TriggerEvent()
    {
        lc.StartGame();
        Debug.Log("oyun başladı broo");
    }
}
