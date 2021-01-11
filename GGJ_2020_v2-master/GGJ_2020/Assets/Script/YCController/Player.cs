using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public YCController yc;
    public IController isaac;
    public bool isIsaac = true;
    public float hope;
    public float hopeLose;

    bool avatarType;//false = yiğit , true = isaac

    void Update()
    {
        
    }


    public void AvatarChange(bool state)
    {
        avatarType = state;
        SetPlayersLockState();
    }

    public void SetPlayersLockState()
    {
        if (avatarType)
        {
            isaac.UnLockPlayer();
            yc.LockPlayer();
        }
        else
        {
            isaac.LockPlayer();
            yc.UnlockPlayer(); 
        }
    }
}
