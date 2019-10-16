using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Player")
        {
            if (other.transform.parent.parent.GetComponent<Move>().way == 0)
                other.transform.parent.parent.Rotate(0, 90, 0);

            else if (other.transform.parent.parent.GetComponent<Move>().way == 1)
                other.transform.parent.parent.Rotate(0, -90, 0);

            if (other.transform.parent.parent.GetComponent<Move>().fevered)
                other.transform.parent.parent.GetComponent<Rigidbody>().velocity = other.transform.parent.parent.forward * 7;

            else
                other.transform.parent.parent.GetComponent<Rigidbody>().velocity = other.transform.parent.parent.forward * 3.5f;

            other.transform.parent.parent.GetComponent<Move>().way++;
            other.transform.parent.parent.GetComponent<Move>().ForeseeTurn();
        }
    }
}
