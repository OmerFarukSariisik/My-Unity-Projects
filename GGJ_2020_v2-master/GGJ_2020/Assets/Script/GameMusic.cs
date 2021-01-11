using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{

    public AudioSource yigitMusic;
    float yigitMusicTargetVolume;
    public AudioSource hopeMusic;
    float hopeMusicTargetVolume;
    public AudioSource hopelessMusic;
    float hopelessMusicTargetVolume;
    public LevelController levelController;

    int isaacCount;

    bool state;//false = yiğit , true = isaac
    float time;
    void Start()
    {
        state = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelController.cameraState != state)
        {
            state = levelController.cameraState;
            time = Time.time;
            if (state)
            {
                isaacCount = 0;
                yigitMusic.volume = 0;
                hopeMusic.volume = 100;
                hopelessMusic.volume = 0;
            }else
            {
                yigitMusic.volume = 100;
                hopeMusic.volume = 0;
                hopelessMusic.volume = 0;
            }
        }

        if(Time.time - time > 30.0f)
        {
            if (state)
            {
                isaacCount++;
                if (isaacCount == 2)
                {
                    isaacCount = 0;
                }
                if (isaacCount == 0)
                {
                    hopeMusic.volume = 100;
                    hopelessMusic.volume = 0;
                }
                if (isaacCount == 1)
                {
                    hopeMusic.volume = 0;
                    hopelessMusic.volume = 100;
                }

            }
            time = Time.time;
        }




    }
}
