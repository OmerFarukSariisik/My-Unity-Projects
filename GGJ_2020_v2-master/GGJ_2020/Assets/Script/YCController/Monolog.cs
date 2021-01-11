using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monolog : MonoBehaviour
{
    public AudioClip yc;
    public AudioClip out1;
    public AudioClip out2;
    private AudioSource au;
    float timer;
    public bool monolog = false;
    bool ycIntro = false;
    bool outro1 = false;
    bool outro2 = false;

    public void YigitIntro()
    {
        monolog = true;
        ycIntro = true;
        au.clip = yc;
        au.Play();
    }
    public void FirstOutro()
    {
        monolog = true;
        outro1 = true;
        au.clip = out1;
        au.Play();
    }
    public void SecondOutro()
    {
        monolog = true;
        outro2 = true;
        au.clip = out2;
        au.Play();
    }

    void Start()
    {
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ycIntro)
        {
            timer += Time.deltaTime;
            if (timer > 11)
            {
                ycIntro = false;
                monolog = false;
                timer = 0;
            }
        }
        else if (outro1)
        {
            timer += Time.deltaTime;
            if (timer > 11)
            {
                outro1 = false;
                monolog = false;
                timer = 0;
            }
        }
        else if (outro2)
        {
            timer += Time.deltaTime;
            if (timer > 7)
            {
                outro2 = false;
                monolog = false;
                timer = 0;
            }
        }
    }
}
