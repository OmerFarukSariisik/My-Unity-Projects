using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnsweringMachine : MonoBehaviour
{
    public AudioClip[] messages;
    private AudioSource au;
    private GameMaster gm;
    private bool ch1 = false;
    private bool ch2 = false;
    private bool ch3 = false;
    private float timer;

    public void PlayTheMessage()
    {
        if (gm.Chapter == 1)
        {
            ch1 = true;
            au.clip = messages[0];
            au.Play();
        }
         if (gm.Chapter == 2)
        {
            ch2 = true;
            au.clip = messages[2];
            au.Play();
        }
         if (gm.Chapter == 3)
        {
            ch3 = true;
            au.clip = messages[4];
            au.Play();
        }
         
    }
    void Start()
    {
        au = GetComponent<AudioSource>();
        gm = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
    }
    private void Update()
    {
        if (ch1)
        {
            timer += Time.deltaTime;
            
            if(timer > 15)
            {
                au.clip = messages[1];
                au.Play();
                ch1 = false;
                timer = 0;
            }
        }
        else if (ch2)
        {
            timer += Time.deltaTime;
            
            if(timer > 9)
            {
                au.clip = messages[3];
                au.Play();
                ch2 = false;
                timer = 0;
            }
        }
        else if (ch3)
        {
            timer += Time.deltaTime;
            
            if(timer > 12)
            {
                au.clip = messages[5];
                au.Play();
                ch3 = false;
                timer = 0;
            }
        }

    }
}
