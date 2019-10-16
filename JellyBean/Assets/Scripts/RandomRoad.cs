using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoad : MonoBehaviour
{
    private int road;

    public GameObject Road1;
    public GameObject Road2;
    public GameObject LongObs;
    public GameObject ShortObs;
    public GameObject Gem;
    public bool gemLevel = false;

    public List<Vector3> obstaclePositions = new List<Vector3>();
    public List<GameObject> obstacles = new List<GameObject>();

    void Start()
    {
        InstantiateWays();
        InstantiateObstacles();
    }

    private void InstantiateWays()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                Instantiate(Road1, transform);
                road = 1;
                break;
            case 2:
                Instantiate(Road2, transform);
                road = 2;
                break;
        }
    }

    private void InstantiateObstacles()
    {
        int obstacleCount = 0;
        for(int i = 0; i < 3; i++)
        {
            obstacleCount = Random.Range(4, 8);
            List<int> locations = new List<int>();

            for (int j = 0; j < obstacleCount; j++)
            {
                int location = Random.Range(1, 8);

                if (locations.Contains(location))
                    j--;
                else
                    locations.Add(location);
            }
            locations.Sort();
            foreach (int a in locations)
            {
                CreateObstacle(a, i);
            }
        }
    }

    private void CreateObstacle(int location, int way)
    {
        int shortOrLong = Random.Range(1, 3);

        if (way == 0)
            obstaclePositions.Add(new Vector3(0, 0, Random.Range(location * 4, location * 4 + 3)));

        else if (road == 1)
        {
            if (way == 1)
                obstaclePositions.Add(new Vector3(Random.Range(location * 4, location * 4 + 3), 0, 36));
            else if (way == 2)
                obstaclePositions.Add(new Vector3(38, 0, Random.Range(location + 37 + location * 3, location + 40 + location * 3)));
        }

        else if(road == 2)
        {
            if (way == 1)
                obstaclePositions.Add(new Vector3(-Random.Range(location * 4, location * 4 + 3), 0, 36));
            else if (way == 2)
                obstaclePositions.Add(new Vector3(-38, 0, Random.Range(location + 37 + location * 3, location + 40 + location * 3)));
        }

        obstacles.Add(Instantiate(shortOrLong == 1 ? ShortObs : LongObs, obstaclePositions[obstaclePositions.Count - 1], way == 1 ? Quaternion.Euler(0, 90, 0) : Quaternion.identity));
        if(gemLevel)
            CreateGems(way);
    }

    private void CreateGems(int way)
    {
        int pos = (int)obstacles[obstacles.Count - 1].transform.position.z;
        int pos2 = 0;
        if (obstacles.Count > 1)
            pos2 = (int)obstacles[obstacles.Count - 2].transform.position.z;

        if (obstacles.Count > 1)
        {
            if(pos - pos2 > 2)
            {
                for (int i = pos2 + 1; i < pos - 1; i++)
                {
                    if(way == 0)
                    {
                        Instantiate(Gem, new Vector3(-0.5f, 0.32f, i), Quaternion.identity);
                        Instantiate(Gem, new Vector3(0.5f, 0.32f, i), Quaternion.identity);
                    }
                    else if(road == 1)
                    {
                        if(way == 1)
                        {
                            Instantiate(Gem, new Vector3(i , 0.32f, 36), Quaternion.identity);
                            Instantiate(Gem, new Vector3(i , 0.32f, 36), Quaternion.identity);
                        }
                        else if(way == 2)
                        {
                            Instantiate(Gem, new Vector3(38, 0.32f, i), Quaternion.identity);
                            Instantiate(Gem, new Vector3(38, 0.32f, i), Quaternion.identity);
                        }
                    }
                    else if (road == 2)
                    {
                        if (way == 1)
                        {
                            Instantiate(Gem, new Vector3(-i, 0.32f, 36), Quaternion.identity);
                            Instantiate(Gem, new Vector3(-i, 0.32f, 36), Quaternion.identity);
                        }
                        else if (way == 2)
                        {
                            Instantiate(Gem, new Vector3(-38, 0.32f, i), Quaternion.identity);
                            Instantiate(Gem, new Vector3(-38, 0.32f, i), Quaternion.identity);
                        }
                    }
                }
            }
        }
    }
}
