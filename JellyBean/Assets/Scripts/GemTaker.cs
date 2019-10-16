using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemTaker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent.parent.GetComponent<GemKeeper>().IncreaseGem();
            Destroy(transform.parent.gameObject);
        }
    }
}
