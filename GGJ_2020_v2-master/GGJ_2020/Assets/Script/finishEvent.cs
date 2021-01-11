using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishEvent : MonoBehaviour
{
    public Player player;
    public LevelController levelController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cameraState != cameraState;

        }
    }
}
