using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : MonoBehaviour
{
    private bool passed = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!passed)
            {
                other.transform.parent.parent.GetComponent<Move>().Fever();
                other.transform.parent.parent.GetComponent<Move>().Foresee();
                passed = true;
            }
        }
    }
}
