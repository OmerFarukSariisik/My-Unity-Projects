using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiCarpmasi : MonoBehaviour
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
        if (other.CompareTag("parca"))
        {
            ScoreText.scoreValue += 1;
            other.gameObject.GetComponentInParent<DusmanDavranis>().Die();
            other.gameObject.GetComponentInParent<Rigidbody>().AddForce(transform.up * 5000f);
        }
    }
}
