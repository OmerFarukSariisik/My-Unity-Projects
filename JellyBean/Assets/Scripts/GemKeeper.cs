using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemKeeper : MonoBehaviour
{
    private int gemCount = 0;
    public Text gemText;
    void Start()
    {
        if (PlayerPrefs.HasKey("Gem"))
        {
            gemCount = PlayerPrefs.GetInt("Gem");
        }
        else
        {
            PlayerPrefs.SetInt("Gem", 0);
        }
        gemText.text = "GEM : " + gemCount;
    }

    public void IncreaseGem()
    {
        gemCount++;
        PlayerPrefs.SetInt("Gem", gemCount);
    }

    public void WriteGem()
    {
        gemText.text = "GEM : " + gemCount;
    }
}
