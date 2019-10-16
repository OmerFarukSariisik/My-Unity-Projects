using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DusmanDavranis : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform oyuncuYeri;
    public void SetKinematic(bool value)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = value;
            rb.gameObject.tag = "parca";
        }
    }

    public void SetTrigger(bool value)
    {
        BoxCollider[] bCol = GetComponentsInChildren<BoxCollider>();
        CapsuleCollider[] cCol = GetComponentsInChildren<CapsuleCollider>();
        SphereCollider[] sCol = GetComponentsInChildren<SphereCollider>();

        var all = bCol.Zip(cCol, (b, c) => new {b, c}).Zip(sCol, (x, s) => new {Box = x.b, Capsule = x.c, Sphere = s});
        foreach (var col in all)
        {
            col.Box.isTrigger = value;
            col.Capsule.isTrigger = value;
            col.Sphere.isTrigger = value;
        }
    }

    void Start()
    {
        SetKinematic(true);
        SetTrigger(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            transform.Translate((transform.position - oyuncuYeri.position).normalized * 0.08f);
            transform.LookAt(oyuncuYeri);
        }
    }

    public void Die()
    {
        SetTrigger(false);
        SetKinematic(false);
        GetComponent<Animator>().enabled = false;
        Destroy(gameObject, 5);
    }
}
