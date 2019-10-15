using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo PI;
    public char team;
    public string mySelectedChar;
    public GameObject[] allChars;

    private void OnEnable()
    {
        if(PI == null)
        {
            PI = this;
        }
        else
        {
            if(PI != this)
            {
                Destroy(PI.gameObject);
                PI = this;
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("MyChar"))
        {
            mySelectedChar = PlayerPrefs.GetString("MyChar");
        }
        else
        {
            mySelectedChar = "A";
            PlayerPrefs.SetString("MyChar", mySelectedChar);
        }
    }
}
