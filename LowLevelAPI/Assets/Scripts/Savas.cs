using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Savas : MonoBehaviour
{
    public bool firstToSecond = false;
    public bool secondToFirst = false;
    private string msg;
    public bool sended1 = false;
    public bool sended2 = false;
    public bool isHome1 = false;
    public bool isHome2 = false;

    public bool battle;

    private Client client;

    private GameObject player1;
    private GameObject player2;

    private Animator animator1;
    private Animator animator2;

    public GameObject assassin;
    public GameObject ghost;
    public GameObject iceman;
    public GameObject witch;

    public GameObject field1;
    public GameObject field2;

    public RectTransform towerHealth1;
    public RectTransform towerHealth2;
    private RectTransform energy1;
    private RectTransform energy2;
    private RectTransform health1;
    private RectTransform health2;
    public static Savas Instance { set; get; }

    private void Start()
    {
        Instance = this;
        client = FindObjectOfType<Client>();
    }

    private void Update()
    {
        if (!firstToSecond)
            sended1 = false;
        if (!secondToFirst)
            sended2 = false;

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            if(client.number == 1)
                msg = "M|" + Input.GetAxis("Vertical").ToString() + "|" + Input.GetAxis("Horizontal").ToString() + "|" + firstToSecond + "|" + isHome1 + "|" + battle;
            else
                msg = "M|" + Input.GetAxis("Vertical").ToString() + "|" + Input.GetAxis("Horizontal").ToString() + "|" + secondToFirst + "|" + isHome2 + "|" + battle;

            client.Send(msg);
        }
    }

    public void Yuru(float x1, float y1, float z1, float x2, float y2, float z2, int who)
    {
        if (who == 1)
        {
            player1.transform.position = new Vector3(x1, y1, z1);
            player1.transform.rotation = Quaternion.Euler(x2, y2, z2);
        }
        if (who == 2)
        {
            player2.transform.position = new Vector3(x1, y1, z1);
            player2.transform.rotation = Quaternion.Euler(x2, y2, z2);
        }
    }
    public void Create(char hero1, char hero2)
    {
        switch (hero1)
        {
            case 's':
                player1 = Instantiate(assassin, new Vector3(0, 0, -7), Quaternion.identity);
                break;
            case 'w':
                player1 = Instantiate(witch, new Vector3(0, 0, -7), Quaternion.identity);
                break;
            case 'g':
                player1 = Instantiate(ghost, new Vector3(0, 0, -7), Quaternion.identity);
                break;
            case 'i':
                player1 = Instantiate(iceman, new Vector3(0, 0, -7), Quaternion.identity);
                break;
        }

        switch (hero2)
        {
            case 's':
                player2 = Instantiate(assassin, new Vector3(0, 0, 7), Quaternion.Euler(0, 180, 0));
                break;
            case 'w':
                player2 = Instantiate(witch, new Vector3(0, 0, 7), Quaternion.Euler(0, 180, 0));
                break;
            case 'g':
                player2 = Instantiate(ghost, new Vector3(0, 0, 7), Quaternion.Euler(0, 180, 0));
                break;
            case 'i':
                player2 = Instantiate(iceman, new Vector3(0, 0, 7), Quaternion.Euler(0, 180, 0));
                break;
        }

        animator1 = player1.GetComponent<Animator>();
        animator2 = player2.GetComponent<Animator>();

        if (client.number == 1)
            player2.transform.GetChild(0).gameObject.SetActive(false);
        if (client.number == 2)
            player1.transform.GetChild(0).gameObject.SetActive(false);

        player1.tag = "Player1";
        player2.tag = "Player2";

        energy1 = player1.transform.GetChild(1).transform.GetChild(0).GetComponent<RectTransform>();
        energy2 = player2.transform.GetChild(1).transform.GetChild(0).GetComponent<RectTransform>();

        health1 = player1.transform.GetChild(2).transform.GetChild(0).GetComponent<RectTransform>();
        health2 = player2.transform.GetChild(2).transform.GetChild(0).GetComponent<RectTransform>();
    }

    public void ShootTheTower(int who, float health)
    {
        if (who == 1)
            towerHealth1.sizeDelta = new Vector2(health, towerHealth1.sizeDelta.y);
        else
            towerHealth2.sizeDelta = new Vector2(health, towerHealth2.sizeDelta.y);
    }

    public void ReduceEnergy(int who, float energy)
    {
        if (who == 1)
            energy1.sizeDelta = new Vector2(energy, energy1.sizeDelta.y);
        else
            energy2.sizeDelta = new Vector2(energy, energy2.sizeDelta.y);

    }

    public void Fight(int who, float health)
    {
        if (who == 1)
            health1.sizeDelta = new Vector2(health, health1.sizeDelta.y);
        else
            health2.sizeDelta = new Vector2(health, health2.sizeDelta.y);

    }
}
