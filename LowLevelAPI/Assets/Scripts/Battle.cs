using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player2")
            Savas.Instance.battle = true;
        else if (other.tag == "Player1")
            Savas.Instance.battle = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player2")
            Savas.Instance.battle = false;
        else if (other.tag == "Player1")
            Savas.Instance.battle = false;
    }
}
