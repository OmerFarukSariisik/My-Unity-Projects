using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Text text;

    public GameObject Shiba;
    public GameObject Shiba2;
    public GameObject Shiba3;
    public GameObject Ceku1;
    public GameObject Ceku2;
    public GameObject Ceku3;
    public GameObject Ceku4;
    public GameObject Lion;

    public GameObject Asi;
    public GameObject Bandage;
    public GameObject Bone;

    Vector3[] hastapos;
    bool[] doluMu;
    bool[] hastaMi;
    bool first = true;

    float time;
    int rnd;

    void Start()
    {
        gm = this;
        doluMu = new bool[5];
        hastaMi = new bool[8];

        hastapos = new Vector3[5];
        hastapos[0] = new Vector3(-1.73f, 1.16f, -3.21f);
        hastapos[1] = new Vector3(0.15f, 1.16f, -3.21f);
        hastapos[2] = new Vector3(1.78f, 1.16f, -3.21f);
        hastapos[3] = new Vector3(3.47f, 1.16f, -3.21f);
        hastapos[4] = new Vector3(5.32f, 1.16f, -3.21f);
    }


    void Update()
    {
        if(Time.time - time > 10)
        {
            rnd = Random.Range(0, 8);

            int x = 0;
            bool iptal = false;

            while (hastaMi[rnd])
            {
                rnd = Random.Range(0, 8);
                x++;
                if(x == 12)
                {
                    iptal = true;
                    break;
                }
            }
            if (iptal)
                return;

            hastaMi[rnd] = true;
            x = 0;

            GameObject needObject = null;
            int need = Random.Range(0, 3);

            switch (rnd)
            {
                case 0:
                    rnd = Random.Range(0, 5);
                    
                    while (doluMu[rnd])
                    {
                        rnd = Random.Range(0, 5);
                        x++;
                        if (x == 12)
                        {
                            iptal = true;
                            break;
                        }
                    }
                    if(iptal)
                        break;

                    if (first)
                        text.text = "Shiba: ";
                    else
                        text.text += "\nShiba: ";

                    first = !first;

                    Shiba.GetComponent<AudioSource>().Play();
                    StartCoroutine(Fail(1));

                    hastapos[rnd].y = 1.156f;
                    Shiba.transform.position = hastapos[rnd];
                    Shiba.GetComponent<Animal>().hastaMiyim = true;
                    Shiba.GetComponent<Animal>().bedNo = rnd + 1;
                    doluMu[rnd] = true;
                    break;
                case 1:
                    rnd = Random.Range(0, 5);

                    while (doluMu[rnd])
                    {
                        rnd = Random.Range(0, 5);
                        x++;
                        if (x == 12)
                        {
                            iptal = true;
                            break;
                        }
                    }
                    if (iptal)
                        break;

                    if (first)
                        text.text = "Max: ";
                    else
                        text.text += "\nMax: ";

                    first = !first;

                    Shiba2.GetComponent<AudioSource>().Play();
                    StartCoroutine(Fail(2));

                    hastapos[rnd].y = 1.12f;
                    Shiba2.transform.position = hastapos[rnd];
                    Shiba2.GetComponent<Animal>().hastaMiyim = true;
                    Shiba2.GetComponent<Animal>().bedNo = rnd + 1;
                    doluMu[rnd] = true;
                    break;
                case 2:
                    rnd = Random.Range(0, 5);

                    while (doluMu[rnd])
                    {
                        rnd = Random.Range(0, 5);
                        x++;
                        if (x == 12)
                        {
                            iptal = true;
                            break;
                        }
                    }
                    if (iptal)
                        break;

                    if (first)
                        text.text = "Duke: ";
                    else
                        text.text += "\nDuke: ";

                    first = !first;

                    Shiba3.GetComponent<AudioSource>().Play();
                    StartCoroutine(Fail(3));

                    hastapos[rnd].y = 0.581f;
                    Shiba3.transform.position = hastapos[rnd];
                    Shiba3.GetComponent<Animal>().hastaMiyim = true;
                    Shiba3.GetComponent<Animal>().bedNo = rnd + 1;
                    doluMu[rnd] = true;
                    break;
                case 3:
                    rnd = Random.Range(0, 5);

                    while (doluMu[rnd])
                    {
                        rnd = Random.Range(0, 5);
                        x++;
                        if (x == 12)
                        {
                            iptal = true;
                            break;
                        }
                    }
                    if (iptal)
                        break;

                    if (first)
                        text.text = "Ceku: ";
                    else
                        text.text += "\nCeku: ";

                    first = !first;

                    Ceku1.GetComponent<AudioSource>().Play();
                    StartCoroutine(Fail(4));

                    hastapos[rnd].y = 0.584f;
                    Ceku1.transform.position = hastapos[rnd];
                    Ceku1.GetComponent<Animal>().hastaMiyim = true;
                    Ceku1.GetComponent<Animal>().bedNo = rnd + 1;
                    doluMu[rnd] = true;
                    break;
                case 4:
                    rnd = Random.Range(0, 5);

                    while (doluMu[rnd])
                    {
                        rnd = Random.Range(0, 5);
                        x++;
                        if (x == 12)
                        {
                            iptal = true;
                            break;
                        }
                    }
                    if (iptal)
                        break;

                    if (first)
                        text.text = "Kitty: ";
                    else
                        text.text += "\nKitty: ";

                    first = !first;

                    Ceku2.GetComponent<AudioSource>().Play();
                    StartCoroutine(Fail(5));

                    hastapos[rnd].y = 0.726f;
                    Ceku2.transform.position = hastapos[rnd];
                    Ceku2.GetComponent<Animal>().hastaMiyim = true;
                    Ceku2.GetComponent<Animal>().bedNo = rnd + 1;
                    doluMu[rnd] = true;
                    break;
                case 5:
                    rnd = Random.Range(0, 5);

                    while (doluMu[rnd])
                    {
                        rnd = Random.Range(0, 5);
                        x++;
                        if (x == 12)
                        {
                            iptal = true;
                            break;
                        }
                    }
                    if (iptal)
                        break;

                    if (first)
                        text.text = "Ollie: ";
                    else
                        text.text += "\nOllie: ";

                    first = !first;

                    Ceku3.GetComponent<AudioSource>().Play();
                    StartCoroutine(Fail(6));

                    hastapos[rnd].y = 0.657f;
                    Ceku3.transform.position = hastapos[rnd];
                    Ceku3.GetComponent<Animal>().hastaMiyim = true;
                    Ceku3.GetComponent<Animal>().bedNo = rnd + 1;
                    doluMu[rnd] = true;
                    break;
                case 6:
                    rnd = Random.Range(0, 5);

                    while (doluMu[rnd])
                    {
                        rnd = Random.Range(0, 5);
                        x++;
                        if (x == 12)
                        {
                            iptal = true;
                            break;
                        }
                    }
                    if (iptal)
                        break;

                    if (first)
                        text.text = "Sophie: ";
                    else
                        text.text += "\nSophie: ";

                    first = !first;

                    Ceku4.GetComponent<AudioSource>().Play();
                    StartCoroutine(Fail(7));

                    hastapos[rnd].y = 0.631f;
                    Ceku4.transform.position = hastapos[rnd];
                    Ceku4.GetComponent<Animal>().hastaMiyim = true;
                    Ceku4.GetComponent<Animal>().bedNo = rnd + 1;
                    doluMu[rnd] = true;
                    break;
                case 7:
                    rnd = Random.Range(0, 5);

                    while (doluMu[rnd])
                    {
                        rnd = Random.Range(0, 5);
                        x++;
                        if (x == 12)
                        {
                            iptal = true;
                            break;
                        }
                    }
                    if (iptal)
                        break;

                    if (first)
                        text.text = "Lionell: ";
                    else
                        text.text += "\nLionell: ";

                    first = !first;

                    Lion.GetComponent<AudioSource>().Play();
                    StartCoroutine(Fail(8));

                    hastapos[rnd].y = 0.59f;
                    Lion.transform.position = hastapos[rnd];
                    Lion.GetComponent<Animal>().hastaMiyim = true;
                    Lion.GetComponent<Animal>().bedNo = rnd + 1;
                    doluMu[rnd] = true;
                    break;
                default:
                    break;
            }

            if (iptal)
                return;

            hastapos[rnd].y = 1.16f;
            if (need == 0)
            {
                needObject = Instantiate(Asi, hastapos[rnd] + new Vector3(0, -1.06f, 1.95f), Quaternion.identity);
                text.text += "Asi icin ecza dolabinda 'E' ile asiyi al ve 'F' ile beni iyilestir!";
            }
            else if (need == 1)
            {
                needObject = Instantiate(Bandage, hastapos[rnd] + new Vector3(0, -1.06f, 1.95f), Quaternion.identity);
                text.text += "Pansumana ihtiyacim var, dolaba git ve talimatlari uygula!";
            }
            else if (need == 2)
            {
                needObject = Instantiate(Bone, hastapos[rnd] + new Vector3(0, -1.06f, 1.95f), Quaternion.identity);
                text.text += "Mama icin yemek yerinden 'E' ile mama al ve 'F' ile beni besle!";
            }

            StartCoroutine(FailDestroy(needObject));

            if (rnd == 0)
            {
                needObject.tag = "bed1";
            }
            else if (rnd == 1)
            {
                needObject.tag = "bed2";
            }
            else if (rnd == 2)
            {
                needObject.tag = "bed3";
            }
            else if (rnd == 3)
            {
                needObject.tag = "bed4";
            }
            else if (rnd == 4)
            {
                needObject.tag = "bed5";
            }

            time = Time.time;
        }
    }

    public void Yoket(int number)
    {
        switch (number)
        {
            case 1:
                if (first)
                    text.text = "Shiba: ";
                else
                    text.text += "\nShiba: ";

                first = !first;

                Shiba.transform.Translate(-20, 0, 0);
                Shiba.GetComponent<Animal>().hastaMiyim = false;
                Shiba.GetComponent<Animal>().bedNo = 0;
                hastaMi[0] = false;
                break;
            case 2:
                if (first)
                    text.text = "Max: ";
                else
                    text.text += "\nMax: ";

                first = !first;

                Shiba2.transform.Translate(-20, 0, 0);
                Shiba2.GetComponent<Animal>().hastaMiyim = false;
                Shiba2.GetComponent<Animal>().bedNo = 0;
                hastaMi[1] = false;
                break;
            case 3:
                if (first)
                    text.text = "Duke: ";
                else
                    text.text += "\nDuke: ";

                first = !first;

                Shiba3.transform.Translate(-20, 0, 0);
                Shiba3.GetComponent<Animal>().hastaMiyim = false;
                Shiba3.GetComponent<Animal>().bedNo = 0;
                hastaMi[2] = false;
                break;
            case 4:
                if (first)
                    text.text = "Ceku: ";
                else
                    text.text += "\nCeku: ";

                first = !first;

                Ceku1.transform.Translate(-20, 0, 0);
                Ceku1.GetComponent<Animal>().hastaMiyim = false;
                Ceku1.GetComponent<Animal>().bedNo = 0;
                hastaMi[3] = false;
                break;
            case 5:
                if (first)
                    text.text = "Kitty: ";
                else
                    text.text += "\nKitty: ";

                first = !first;

                Ceku2.transform.Translate(-20, 0, 0);
                Ceku2.GetComponent<Animal>().hastaMiyim = false;
                Ceku2.GetComponent<Animal>().bedNo = 0;
                hastaMi[4] = false;
                break;
            case 6:
                if (first)
                    text.text = "Ollie: ";
                else
                    text.text += "\nOllie: ";

                first = !first;

                Ceku3.transform.Translate(-20, 0, 0);
                Ceku3.GetComponent<Animal>().hastaMiyim = false;
                Ceku3.GetComponent<Animal>().bedNo = 0;
                hastaMi[5] = false;
                break;
            case 7:
                if (first)
                    text.text = "Sophie: ";
                else
                    text.text += "\nSophie: ";

                first = !first;

                Ceku4.transform.Translate(-20, 0, 0);
                Ceku4.GetComponent<Animal>().hastaMiyim = false;
                Ceku4.GetComponent<Animal>().bedNo = 0;
                hastaMi[6] = false;
                break;
            case 8:
                if (first)
                    text.text = "Lionell: ";
                else
                    text.text += "\nLionell: ";

                first = !first;

                Lion.transform.Translate(-20, 0, 0);
                Lion.GetComponent<Animal>().hastaMiyim = false;
                Lion.GetComponent<Animal>().bedNo = 0;
                hastaMi[7] = false;
                break;
            default:
                break;
        }
        text.text += "Tesekkurler insan!";
    }

    public void Bed(int bedNo)
    {
        doluMu[bedNo] = false;
    }

    private IEnumerator Fail(int animal)
    {
        yield return new WaitForSeconds(8f);
        switch (animal)
        {
            case 1:
                if (Shiba.GetComponent<Animal>().hastaMiyim)
                    Yoket(animal);
                break;
            case 2:
                if (Shiba2.GetComponent<Animal>().hastaMiyim)
                    Yoket(animal);
                break;
            case 3:
                if (Shiba3.GetComponent<Animal>().hastaMiyim)
                    Yoket(animal);
                break;
            case 4:
                if (Ceku1.GetComponent<Animal>().hastaMiyim)
                    Yoket(animal);
                break;
            case 5:
                if (Ceku2.GetComponent<Animal>().hastaMiyim)
                    Yoket(animal);
                break;
            case 6:
                if (Ceku3.GetComponent<Animal>().hastaMiyim)
                    Yoket(animal);
                break;
            case 7:
                if (Ceku4.GetComponent<Animal>().hastaMiyim)
                    Yoket(animal);
                break;
            case 8:
                if (Lion.GetComponent<Animal>().hastaMiyim)
                    Yoket(animal);
                break;
            default:
                break;
        }
    }

    private IEnumerator FailDestroy(GameObject need)
    {
        yield return new WaitForSeconds(8f);
        if(need != null)
            Destroy(need);
    }
}
