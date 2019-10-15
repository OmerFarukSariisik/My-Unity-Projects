using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView PV;
    private CharacterController myCC;
    public float moveSpeed;
    public float rotateSpeed;
    void Start()
    {
        PV = GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            BasicMovement();
            BasicRotation();
        }
    }

    void BasicMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myCC.Move(transform.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myCC.Move(-transform.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myCC.Move(-transform.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myCC.Move(transform.right * Time.deltaTime * moveSpeed);
        }
    }

    void BasicRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
        transform.Rotate(new Vector3(0, mouseX, 0));
    }
}
