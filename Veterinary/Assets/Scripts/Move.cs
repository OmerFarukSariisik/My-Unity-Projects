using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject asiResmi;
    public GameObject bandajResmi;
    public GameObject yemekResmi;

    Vector3 walk;
    Quaternion rotation;

    int item = 0;

    void Start()
    {
        walk = new Vector3();
    }

    void Update()
    {
        walk.x = Input.GetAxis("Horizontal");
        walk.z = Input.GetAxis("Vertical");
        transform.position += walk * Time.deltaTime * 3;

        if(walk.magnitude != 0)
        {
            transform.GetChild(0).GetComponent<Animator>().SetBool("yuru", true);
            rotation = Quaternion.LookRotation(walk);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 10);
        }
        else
            transform.GetChild(0).GetComponent<Animator>().SetBool("yuru", false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "asi")
        {
            if (Input.GetKey(KeyCode.E))
            {
                item = 1;
                yemekResmi.SetActive(false);
                bandajResmi.SetActive(false);
                asiResmi.SetActive(true);
            }
        }
        else if(other.tag == "food")
        {
            if (Input.GetKey(KeyCode.E))
            {
                item = 2;
                bandajResmi.SetActive(false);
                asiResmi.SetActive(false);
                yemekResmi.SetActive(true);
            }
        }
        else if (other.tag == "bant")
        {
            if (Input.GetKey(KeyCode.E))
            {
                item = 3;
                asiResmi.SetActive(false);
                yemekResmi.SetActive(false);
                bandajResmi.SetActive(true);
            }
        }
        else if (other.name == "Asi(Clone)")
        {
            if (Input.GetKey(KeyCode.F))
            {
                if(item == 1)
                {
                    if (other.tag == "bed1")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(8);
                        }

                        GameManager.gm.Bed(0);
                    }

                    else if (other.tag == "bed2")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(1);
                    }

                    else if (other.tag == "bed3")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(2);
                    }

                    else if (other.tag == "bed4")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(3);
                    }

                    else if (other.tag == "bed5")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(4);
                    }

                    Destroy(other.gameObject);
                    item = 0;
                    asiResmi.SetActive(false);
                }
            }
        }

        else if (other.name == "Bone(Clone)")
        {
            if (Input.GetKey(KeyCode.F))
            {
                if(item == 2)
                {
                    if (other.tag == "bed1")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(0);
                    }

                    else if (other.tag == "bed2")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(1);
                    }

                    else if (other.tag == "bed3")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(2);
                    }

                    else if (other.tag == "bed4")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(3);
                    }

                    else if (other.tag == "bed5")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(4);
                    }
                    Destroy(other.gameObject);
                    item = 0;
                    yemekResmi.SetActive(false);
                }
            }
        }

        else if (other.name == "Bandage(Clone)")
        {
            if (Input.GetKey(KeyCode.F))
            {
                if(item == 3)
                {
                    if (other.tag == "bed1")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 1)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(0);
                    }

                    else if (other.tag == "bed2")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 2)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(1);
                    }

                    else if (other.tag == "bed3")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 3)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(2);
                    }

                    else if (other.tag == "bed4")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 4)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(3);
                    }

                    else if (other.tag == "bed5")
                    {
                        if (GameManager.gm.Shiba.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(1);
                        }
                        else if (GameManager.gm.Shiba2.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(2);
                        }
                        else if (GameManager.gm.Shiba3.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(3);
                        }
                        else if (GameManager.gm.Ceku1.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(4);
                        }
                        else if (GameManager.gm.Ceku2.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(5);
                        }
                        else if (GameManager.gm.Ceku3.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(6);
                        }
                        else if (GameManager.gm.Ceku4.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(7);
                        }
                        else if (GameManager.gm.Lion.GetComponent<Animal>().bedNo == 5)
                        {
                            GameManager.gm.Yoket(8);
                        }
                        GameManager.gm.Bed(4);
                    }
                    Destroy(other.gameObject);
                    item = 0;
                    bandajResmi.SetActive(false);
                }
            }
        }
    }
}
