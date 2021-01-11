using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    Light light;
    float lightTarget;
    float zaman;
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - zaman > 0.5f)
        {
            lightTarget = Random.Range(0, 15);
            zaman = Time.time;
        }

        //light.intensity = Vector3.Lerp(light.intensity, lightTarget, 1);
    }
}
