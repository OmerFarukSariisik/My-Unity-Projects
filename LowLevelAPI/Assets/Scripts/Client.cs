using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public class Client : MonoBehaviour
{
    public string clientName;
    public int number;
    public char hero;
    public float towerHealth = 200;

    private bool sended = false;
    private bool socketReady;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamReader reader;
    private StreamWriter writer;

    private List<GameClient> players = new List<GameClient>();

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public bool ConnectToServer(string host, int port)
    {
        if (socketReady)
            return false;

        try
        {
            socket = new TcpClient(host, port);
            stream = socket.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);

            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket Error : " + e.Message);
        }

        return socketReady;
    }

    private void Update()
    {
        if (socketReady)
        {
            if (stream.DataAvailable)
            {
                string data = reader.ReadLine();
                if (data != null)
                    OnIncomingData(data);
            }
        }
    }
    public void Send(string data)
    {
        if (!socketReady)
            return;

        writer.WriteLine(data);
        writer.Flush();
    }
    private void OnIncomingData(string data)
    {
        Debug.Log("Client : " + data);
        string[] aData = data.Split('|');

        if (aData[0] == "M")
        {
            Savas.Instance.Yuru(float.Parse(aData[1]), float.Parse(aData[2]), float.Parse(aData[3]), float.Parse(aData[4]), float.Parse(aData[5]), float.Parse(aData[6]), int.Parse(aData[8]));
            Savas.Instance.ShootTheTower(int.Parse(aData[8]), float.Parse(aData[7]));
        }
        else if(aData[0] == "H")
        {
            Savas.Instance.ReduceEnergy(int.Parse(aData[2]), float.Parse(aData[1]));
        }
        else if(aData[0] == "A")
        {
            Savas.Instance.Fight(int.Parse(aData[2]), float.Parse(aData[1]));
        }
        else if(aData[0] == "S")
        {
            if (aData[1] == "1")
                Savas.Instance.firstToSecond = true;
            else
                Savas.Instance.secondToFirst = true;
        }
        else if(aData[0] == "E")
        {
            if (aData[1] == "1")
                Savas.Instance.firstToSecond = false;
            else
                Savas.Instance.secondToFirst = false;
        }
        else
        {
            switch (aData[0])
            {
                case "SWHO":
                    for (int i = 1; i < aData.Length - 1; i++)
                    {
                        UserConnected(aData[i], true);
                    }
                    Send("CWHO|" + clientName);
                    break;

                case "SCNN":
                    UserConnected(aData[1], false);
                    if (!sended)
                    {
                        Send("CNOM|");
                    }
                    sended = true;
                    break;

                case "SNUM":
                    Send("CNUM|" + number.ToString());
                    break;

                case "SREADY":
                    ChoiceManager.Instance.StartGame();
                    if (number == 1)
                        Send("CCRE|");
                    break;

                case "SCRE":
                    Savas.Instance.Create(aData[1][0], aData[2][0]);
                    break;
            }
        }
    }

    private void UserConnected(string name, bool host)
    {
        GameClient c = new GameClient();
        c.name = name;

        players.Add(c);
        if(players.Count == 1 && !host)
        {
            number = 1;
        }
        if (players.Count == 2)
        {
            if(!host && number != 1)
                number = 2;
            GameManager.Instance.StartChoice();
        }
    }
    private void OnApplicationQuit()
    {
        CloseSocket();
    }
    private void OnDisable()
    {
        CloseSocket();
    }
    private void CloseSocket()
    {
        if (!socketReady)
            return;
        writer.Close();
        reader.Close();
        socket.Close();
        socketReady = false;
    }
}

public class GameClient
{
    public string name;
}