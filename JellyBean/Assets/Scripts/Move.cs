using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    private bool gameStarted = false;

    private float differ = 0;
    private float oldMousePos;
    private GameObject cube;

    private int foresee;
    private GameObject foreseen;
    private List<Vector3> obstaclePos;
    private List<GameObject> obstacles;

    private int fever = 0;
    public bool fevered = false;

    private float speed = 3.5f;
    public bool crashed = false;
    public bool levelFinished = false;

    public int way = 0;

    public Canvas startCanvas;
    private void Start()
    {
        cube = transform.GetChild(0).gameObject;
        obstaclePos = GameObject.Find("RandomRoad").GetComponent<RandomRoad>().obstaclePositions;
        obstacles = GameObject.Find("RandomRoad").GetComponent<RandomRoad>().obstacles;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!gameStarted)
            {
                for(int i = 0; i < 5; i++)
                {
                    startCanvas.transform.GetChild(i).gameObject.SetActive(false);
                }
                startCanvas.transform.GetChild(5).gameObject.SetActive(true);

                GetComponent<Rigidbody>().velocity = transform.forward * speed;
                gameStarted = true;
                Foresee();
            }

            ChangeShape();
        }

        if (crashed)
        {
            speed = -20;
            fever = 0;
            startCanvas.transform.GetChild(5).GetChild(0).GetComponent<Image>().fillAmount = fever / 5.0f;
            crashed = false;
        }
        if (speed < 3.5f && !levelFinished)
        {
            //Çarpışmadan sonra:
            SpeedUp();
        }
    }

    private void ChangeShape()
    {
        differ = Input.mousePosition.y - oldMousePos;

        if (differ < 0)
        {
            if (cube.GetComponent<Transform>().localScale.y > 0.2f)
            {
                cube.transform.localScale -= new Vector3(0, 0.04f, 0);
                cube.transform.localScale += new Vector3(0.04f, 0, 0);
                if (foresee - 1 < obstaclePos.Count)
                {
                    foreseen.transform.localScale -= new Vector3(0, 0.04f, 0);
                    foreseen.transform.localScale += new Vector3(0.04f, 0, 0);
                }
            }
            oldMousePos = Input.mousePosition.y;
        }
        else if (differ > 0)
        {
            if (cube.GetComponent<Transform>().localScale.y < 1.2f)
            {
                cube.GetComponent<Transform>().localScale += new Vector3(0, 0.04f, 0);
                cube.GetComponent<Transform>().localScale -= new Vector3(0.04f, 0, 0);
                if (foresee - 1 < obstaclePos.Count)
                {
                    foreseen.transform.localScale += new Vector3(0, 0.04f, 0);
                    foreseen.transform.localScale -= new Vector3(0.04f, 0, 0);
                }
            }
            oldMousePos = Input.mousePosition.y;
        }
    }

    private void SpeedUp()
    {
        if (speed < -15)
            speed += 17;
        speed += 0.1f;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    public void Fever()
    {
        fever++;

        if (!fevered)
        {
            startCanvas.transform.GetChild(5).GetChild(0).GetComponent<Image>().fillAmount = fever / 5.0f;

            if (fever == 5)
            {
                startCanvas.transform.GetChild(5).GetChild(0).GetComponent<Image>().color = Color.red;
                fever = 0;
                fevered = true;
                speed = 7;
                GetComponent<Rigidbody>().velocity = transform.forward * speed;
            }
        }
        else
        {
            startCanvas.transform.GetChild(5).GetChild(0).GetComponent<Image>().fillAmount = 5.0f / fever;

            if (fever == 5)
            {
                startCanvas.transform.GetChild(5).GetChild(0).GetComponent<Image>().color = Color.green;
                fever = 0;
                fevered = false;
                speed = 3.5f;
                GetComponent<Rigidbody>().velocity = transform.forward * speed;
            }
        }
    }

    public void Foresee()
    {
        Destroy(foreseen);
        if(foresee != 0)
            Destroy(obstacles[foresee - 1]);

        if (foresee < obstaclePos.Count)
        {
            foreseen = Instantiate(transform.GetChild(0), obstaclePos[foresee], transform.rotation).gameObject;
            foreseen.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        }
        foresee++;
    }

    public void ForeseeTurn()
    {
        foreseen.transform.Rotate(0, 90, 0);
    }

    public void Finish()
    {
        levelFinished = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        startCanvas.transform.GetChild(4).gameObject.SetActive(true);
        startCanvas.transform.GetChild(5).gameObject.SetActive(false);
        startCanvas.transform.GetChild(6).gameObject.SetActive(true);
        startCanvas.transform.GetChild(7).gameObject.SetActive(true);
    }
}
