using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicApollo : MonoBehaviour
{
    public AudioClip deppressiveRoom;
    public AudioClip happyRoom;
    public AudioClip isaacRelax;
    public AudioClip inGameMusic;
    public AudioClip voidMusic;

    private AudioSource au;
    public void PlayMusic(int which)
    {
        switch (which)
        {
            case 1:
                au.clip = deppressiveRoom;
                break;
            case 2:
                au.clip = happyRoom;
                break;
            case 3:
                au.clip = isaacRelax;
                break;
            case 4:
                au.clip = inGameMusic;
                break;
            case 5:
                au.clip = voidMusic;
                break;

            default:
                break;
        }
        au.Play();
    }
    void Start()
    {
        au = GetComponent<AudioSource>();
    }
}
