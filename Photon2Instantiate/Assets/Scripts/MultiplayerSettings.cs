using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerSettings : MonoBehaviour
{
    public static MultiplayerSettings multiplayerSetting;

    public bool delayStart;
    public int maxPlayers;
    public int menuScene;
    public int multiplayerScene;

    void Awake()
    {
        if(multiplayerSetting == null)
        {
            multiplayerSetting = this;
        }
        else
        {
            if(multiplayerSetting != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
