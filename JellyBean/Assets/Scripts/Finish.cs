using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent.parent.GetComponent<Move>().Finish();
            other.transform.parent.parent.GetComponent<GemKeeper>().WriteGem();
        }
    }
}
