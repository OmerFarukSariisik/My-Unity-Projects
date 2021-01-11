﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public static GameSetup GS;
    public Transform[] SpawnPoints;
    private void OnEnable()
    {
        if(GS == null)
        {
            GS = this;
        }
    }
}
