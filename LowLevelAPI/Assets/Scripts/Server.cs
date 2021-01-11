using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.IO;

public class Server : MonoBehaviour
{
    public int port = 6321;
    private List<ServerClient> clients;
    private List<ServerClient> disconnectList;
    
    private TcpListener server;
    private bool serverStarted;
    private int ready;
    private bool gameStarted = false;
    private bool battle = false;

    private GameObject go;
    Vector3 vector;
    Quaternion q = Quaternion.Euler(0, 180, 0);
    private float translation;
    private float rotation;
    private readonly int speed = 80;
    private readonly int rotationSpeed = 60;

    private float time;
    public void Init()
    {
        DontDestroyOnLoad(gameObject);
        clients = new List<ServerClient>();
        disconnectList = new List<ServerClient>();

        try
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();

            StartListening();
            serverStarted = true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket error: " + e.Message);
        }
    }

    private void Update()
    {
        if (!serverStarted)
            return;

        foreach (ServerClient c in clients)
        {
            if (!IsConnected(c.tcp))
            {
                c.tcp.Close();
                disconnectList.Add(c);
                continue;
            }
            else
            {
                NetworkStream s = c.tcp.GetStream();
                if (s.DataAvailable)
                {
                    StreamReader reader = new StreamReader(s, true);
                    string data = reader.ReadLine();

                    if (data != null)
                        OnIncomingData(c, data);
                }
            }
        }

        for(int i = 0; i < disconnectList.Count - 1; i++)
        {
            clients.Remove(disconnectList[i]);
            disconnectList.RemoveAt(i);
        }
        if (gameStarted)
            if (Time.time - time > 0.4f)
            {
                if (battle)
                    if(clients[0].energy != clients[1].energy)
                    {
                        if(clients[0].energy > clients[1].energy)
                        {
                            clients[1].health -= 2.0f;
                            BroadCast("A|" + clients[1].health + "|" + 2, clients);
                        }
                        else
                        {
                            clients[0].health -= 2.0f;
                            BroadCast("A|" + clients[0].health + "|" + 1, clients);
                        }
                    }

                if (!clients[0].isHome) 
                {
                    if (clients[0].energy > 0.0f)
                        clients[0].energy -= 2.0f;
                    BroadCast("H|" + clients[0].energy + "|" + 1, clients);
                }
                else
                {
                    if (clients[0].energy < 100.0f)
                        clients[0].energy += 2.0f;
                    BroadCast("H|" + clients[0].energy + "|" + 1, clients);
                }
                if (!clients[1].isHome)
                {
                    if (clients[1].energy > 0.0f)
                        clients[1].energy -= 2.0f;
                    BroadCast("H|" + clients[1].energy + "|" + 2, clients);
                }
                else
                {
                    if (clients[1].energy < 100.0f)
                        clients[1].energy += 2.0f;
                    BroadCast("H|" + clients[1].energy + "|" + 2, clients);
                }

                if (clients[0].hit)
                {
                    if (clients[1].towerHealth > 0.0f)
                        clients[1].towerHealth -= 2.0f;
                    BroadCast("M|" + clients[1].position.x + "|" + clients[1].position.y + "|" + clients[1].position.z + "|" + clients[1].quaternion.eulerAngles.x + "|" + clients[1].quaternion.eulerAngles.y + "|" + clients[1].quaternion.eulerAngles.z + "|" + clients[1].towerHealth + "|" + 2, clients);
                }
                if (clients[1].hit)
                {
                    if (clients[0].towerHealth > 0.0f)
                        clients[0].towerHealth -= 2.0f;
                    BroadCast("M|" + clients[0].position.x + "|" + clients[0].position.y + "|" + clients[0].position.z + "|" + clients[0].quaternion.eulerAngles.x + "|" + clients[0].quaternion.eulerAngles.y + "|" + clients[0].quaternion.eulerAngles.z + "|" + clients[0].towerHealth + "|" + 1, clients);
                }
                time = Time.time;
            }
    }
    private void StartListening()
    {
        server.BeginAcceptTcpClient(AcceptTcpClient, server);
    }

    private void AcceptTcpClient(IAsyncResult ar)
    {
        TcpListener listener = (TcpListener)ar.AsyncState;

        string allUsers = "";
        foreach (ServerClient i in clients)
        {
            allUsers += i.clientName + '|';
        }

        ServerClient sc = new ServerClient(listener.EndAcceptTcpClient(ar));
        clients.Add(sc);
        StartListening();

        BroadCast("SWHO|" + allUsers, clients[clients.Count - 1]);
    }

    private bool IsConnected(TcpClient c)
    {
        try
        {
            if (c != null && c.Client != null && c.Client.Connected)
            {
                if (c.Client.Poll(0, SelectMode.SelectRead))
                    return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0);

                return true;
            }
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    //Server Send
    private void BroadCast(string data, List<ServerClient> cl)
    {
        foreach (ServerClient sc in cl)
        {
            try
            {
                StreamWriter writer = new StreamWriter(sc.tcp.GetStream());
                writer.WriteLine(data);
                writer.Flush();
            }
            catch (Exception e)
            {
                Debug.Log("Write error : " + e.Message);
            }
        }
    }

    private void BroadCast(string data, ServerClient cl)
    {
        List<ServerClient> sc = new List<ServerClient>() { cl };
        BroadCast(data, sc);
    }

    //Server Read
    private void OnIncomingData(ServerClient c, string data)
    {
        string[] aData = data.Split('|');

        if (aData[0] == "M")
        {
            gameStarted = true;
            c.hit = bool.Parse(aData[3]);
            c.isHome = bool.Parse(aData[4]);
            battle = bool.Parse(aData[5]);

            go = new GameObject();
            go.transform.position = c.position;
            go.transform.rotation = c.quaternion;
            if (float.Parse(aData[1]) != 0)
            {
                translation = float.Parse(aData[1]) * Time.deltaTime * speed;
                go.transform.Translate(0, 0, translation);
                c.position = go.transform.position;
            }
            if (float.Parse(aData[2]) != 0)
            {
                rotation = float.Parse(aData[2]) * Time.deltaTime * rotationSpeed;
                go.transform.Rotate(0, rotation, 0);
                c.quaternion = go.transform.rotation;
            }

            Destroy(go);
            BroadCast("M|" + c.position.x + "|" + c.position.y + "|" + c.position.z + "|" + c.quaternion.eulerAngles.x + "|" + c.quaternion.eulerAngles.y + "|" + c.quaternion.eulerAngles.z + "|" + c.towerHealth + "|" + c.number, clients);
        }
        else if (aData[0] == "S")
        {
            BroadCast("S|" + aData[1], clients);
        }
        else if (aData[0] == "E")
        {
            BroadCast("E|" + aData[1], clients);
        }
        else
        {
            switch (aData[0])
            {
                case "CWHO":
                    c.clientName = aData[1];
                    BroadCast("SCNN|" + c.clientName, clients);
                    break;

                case "CNOM":
                    BroadCast("SNUM|" + c.clientName, clients[clients.Count - 1]);
                    break;

                case "CNUM":
                    c.number = int.Parse(aData[1]);
                    if (c.number % 2 == 1)
                    {
                        c.position = new Vector3(0, 0, -7);
                        c.quaternion = Quaternion.identity;
                    }
                    else
                    {
                        c.position = new Vector3(0, 0, 7);
                        c.quaternion = Quaternion.Euler(0, 180, 0);
                    }

                    if (c.number == 2)
                        Debug.Log("ikinci x: " + clients[1].position.z);

                    Debug.Log("birinci x: " + clients[0].position.z);
                    break;

                case "CHERO":
                    c.hero = aData[1][0];
                    ready += 1;
                    if (ready == 2)
                        BroadCast("SREADY|", clients);
                    break;

                case "CCRE":
                    BroadCast("SCRE|" + clients[0].hero + '|' + clients[1].hero, clients);
                    break;

                default:
                    break;
            }
        }
    }
}

public class ServerClient
{
    public string clientName;
    public TcpClient tcp;
    public int number;
    public char hero;

    public Vector3 position;
    public Quaternion quaternion;

    public bool hit = false;
    public float towerHealth = 200.0f;

    public bool isHome = false;
    public float energy = 100;

    public float health = 100;

    public ServerClient(TcpClient tcp)
    {
        this.tcp = tcp;
    }
}