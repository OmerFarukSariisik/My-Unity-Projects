using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundApollo : MonoBehaviour
{
    public AudioClip dialogueSound;
    private AudioSource au;
    void Start()
    {
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
