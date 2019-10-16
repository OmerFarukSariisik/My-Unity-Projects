using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanOlustur : MonoBehaviour
{
    // Start is called before the first frame update
    private float time = 0;
    private float gecenZaman = 0;
    public GameObject dusman;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time - gecenZaman;

        if(time >= 4)
        {
            gecenZaman = Time.time;
            GameObject yeniDusman = Instantiate(dusman, new Vector3(Random.Range(-18f, 18f),transform.position.y,Random.Range(0f, 50f)), Quaternion.Inverse(transform.rotation));
            yeniDusman.SetActive(true);
            time = 0f;
        }
    }
}
