using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!other.transform.parent.parent.GetComponent<Move>().fevered)
            {
                other.transform.parent.parent.GetComponent<Rigidbody>().velocity = other.transform.parent.parent.forward * -20;
                other.transform.parent.parent.GetComponent<Move>().crashed = true;
            }
            Destroy(gameObject);
        }
    }
}
