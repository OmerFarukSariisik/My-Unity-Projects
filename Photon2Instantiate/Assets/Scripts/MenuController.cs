using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickChar(string which)
    {
        if(PlayerInfo.PI != null)
        {
            PlayerInfo.PI.mySelectedChar = which;
            PlayerPrefs.SetString("MyChar", which);
        }
    }
}
