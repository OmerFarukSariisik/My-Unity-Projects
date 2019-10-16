using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilahAl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject eldekiSilah;
    public GameObject canvas;
    Animator anim;
    void Start()
    {
        Cursor.visible = false;
        anim = canvas.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("silah"))
        {
            Destroy(other.gameObject);
            eldekiSilah.SetActive(true);
        }
        else if (other.CompareTag("parca"))
        {
            anim.SetTrigger("GameOver");
        }
    }
}
