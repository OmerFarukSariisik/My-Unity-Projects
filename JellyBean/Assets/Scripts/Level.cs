using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    private int level = 1;
    public Text levelText;

    void Awake()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        levelText.text = "Level : " + level;

        if (level % 3 == 1)
            GetComponentInParent<RandomRoad>().gemLevel = true;
    }

    public void Finish()
    {
        PlayerPrefs.SetInt("Level", level + 1);
        SceneManager.LoadScene("GameScene");
    }
}
