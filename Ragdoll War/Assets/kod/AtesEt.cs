using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesEt : MonoBehaviour
{
    public GameObject mermi;
    public GameObject tabanca;
    public Transform MermiYeri;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && tabanca.activeInHierarchy)
        {

            GameObject yeniMermi = Instantiate(mermi, MermiYeri.position, MermiYeri.rotation);
            yeniMermi.GetComponent<Rigidbody>().velocity = yeniMermi.transform.up * 50f;

            Destroy(yeniMermi, 5);
        }
    }
}
