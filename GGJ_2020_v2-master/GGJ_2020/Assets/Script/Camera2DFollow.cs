using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.transform.position.x - player.transform.position.x) + Mathf.Abs(this.transform.position.y - player.transform.position.y) > 1)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, -10f), 0.01f);
        }
        

    }
}
