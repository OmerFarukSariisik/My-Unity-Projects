using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IController : MonoBehaviour
{
    public float speed;
    public Camera isaacCam;

    public Vector3 rotation;
    public float realSpeed;
    public GameObject PlayerIsaac;
    public float speedLockTime;

    public float jumpForce;
    public float downForce;
    public bool isJumped;
    public bool isInGround;


    public bool isLocked;
    bool inDialogue;

    NPCDialogue NPCDialogue;

    public Animator anim;

    public Rigidbody rb;
    public float gravity;

    public float verticalVelocity;

    CharacterController controller;

    void Start()
    {
        isJumped = false;
        isLocked = false;
        inDialogue = false;
        isInGround = true;
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {


        if (!isLocked)
        {

            verticalVelocity -= gravity * Time.deltaTime;
            if (isInGround)
            {
                verticalVelocity = -gravity * Time.deltaTime * 80;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    verticalVelocity = jumpForce;
                    isInGround = false;
                }
                    
            }
            
            

            float horizontal = Input.GetAxis("Horizontal");
            rotation = new Vector3(Input.GetAxis("Horizontal") * speed, verticalVelocity, 0);
            
            controller.Move(rotation * Time.deltaTime);

            anim.SetFloat("ivme", Mathf.Abs(horizontal));
            if (horizontal > 0)
            {
                this.transform.eulerAngles = new Vector3(0, 90, 0);
            }
            if (horizontal < 0)
            {
                this.transform.eulerAngles = new Vector3(0, 270, 0);
            }
            if (speedLockTime > Time.time)
            {
                if (Mathf.Abs(realSpeed - speed) > 0.05)
                {
                    speed += (realSpeed - speed) / 30;
                }
            }

            //if (Input.GetKeyDown("space"))
            //{
            //    TriggerNPC(0);
            //}





            if (inDialogue == true)
            {
                if (Input.GetKeyDown("e"))
                {
                    TriggerNPC(0);
                }
                if (Input.GetKeyDown("1"))
                {
                    TriggerNPC(1);
                }
                if (Input.GetKeyDown("2"))
                {
                    TriggerNPC(2);
                }
                if (Input.GetKeyDown("3"))
                {
                    TriggerNPC(3);
                }
                if (Input.GetKeyDown("4"))
                {
                    TriggerNPC(4);
                    
                }
            }







        }
        
        

    }


    public void move(float val)
    {
        
    }

    public void TriggerNPC(int c)  
    {
        print(c);
        NPCDialogue.TriggerEvent(c);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            NPCDialogue = collision.gameObject.GetComponent<NPCDialogue>();
            inDialogue = true;
        }
        if (collision.gameObject.tag == "Zemin")
        {
            isInGround = true;
            print("sdfsdf");
        }
        if (collision.gameObject.tag == "sideWall")
        {

        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            inDialogue = false;
            
        }
        if (collision.gameObject.tag == "Zemin")
        {

            isInGround = false;
            print(isInGround);

        }
        if (collision.gameObject.tag == "sideWall")
        {
            
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (hit.gameObject.tag == "Zemin")
        {
            isInGround = true;
        }

    }



    public void LockPlayer()
    {
        isLocked = true;
    }

    public void UnLockPlayer()
    {
        isLocked = false;
    }

}
