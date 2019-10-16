using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player2")
        {
            if (gameObject.tag == "Tower1")
            {
                Savas.Instance.secondToFirst = true;
            }
            else if(gameObject.tag == "Tower2")
            {
                Savas.Instance.isHome2 = true;
            }
        }
        else if(other.tag == "Player1")
        {
            if(gameObject.tag == "Tower2")
            {
                Savas.Instance.firstToSecond = true;
            }
            else if(gameObject.tag == "Tower1")
            {
                Savas.Instance.isHome1 = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player2")
        {
            if (gameObject.tag == "Tower1")
            {
                Savas.Instance.secondToFirst = false;
            }
            else if (gameObject.tag == "Tower2")
            {
                Savas.Instance.isHome2 = false;
            }
        }
        else if (other.tag == "Player1")
        {
            if (gameObject.tag == "Tower2")
            {
                Savas.Instance.firstToSecond = false;
            }
            else if (gameObject.tag == "Tower1")
            {
                Savas.Instance.isHome1 = false;
            }
        }
    }
}
