using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    //room info
    public static PhotonRoom room;
    private PhotonView PV;
    public bool isGameLoaded;
    public int currentScene;

    //player info
    Player[] photonPlayers;
    public int playersInRoom;
    public int myNumberInRoom;
    public int playerInGame;

    //delayed start
    private bool readyToStart;
    private bool readyToCount;
    public float startingTime;
    private float lessThanMaxPlayers;
    private float atMaxPlayer;
    private float timeToStart;

    private void Awake()
    {
        if(room == null)
        {
            room = this;
        }
        else
        {
            if(room != this)
            {
                Destroy(room.gameObject);
                room = this;
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }
    void Start()
    {
        PV = GetComponent<PhotonView>();
        readyToStart = false;
        readyToCount = false;
        lessThanMaxPlayers = startingTime;
        atMaxPlayer = 6;
        timeToStart = startingTime;
    }
    private void Update()
    {
        if (MultiplayerSettings.multiplayerSetting.delayStart)
        {
            if(playersInRoom == 1)
            {
                RestartTimer();
            }
            if (!isGameLoaded)
            {
                if (readyToStart)
                {
                    atMaxPlayer -= Time.deltaTime;
                    lessThanMaxPlayers = atMaxPlayer;
                    timeToStart = atMaxPlayer;
                }
                else if (readyToCount)
                {
                    lessThanMaxPlayers -= Time.deltaTime;
                    timeToStart = lessThanMaxPlayers;
                    Debug.Log("Display time to start to the players" + timeToStart);
                    if (timeToStart <= 0)
                        StartGame();
                }
            }
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("room joined");
        photonPlayers = PhotonNetwork.PlayerList;
        playersInRoom = photonPlayers.Length;
        myNumberInRoom = playersInRoom;
        PhotonNetwork.NickName = myNumberInRoom.ToString();
        if (MultiplayerSettings.multiplayerSetting.delayStart)
        {
            Debug.Log("Displayer players in room out of max player possible (" + playersInRoom + ":" + MultiplayerSettings.multiplayerSetting.maxPlayers + ")");
            if(playersInRoom > 1)
            {
                readyToCount = true;
            }
            if (playersInRoom == MultiplayerSettings.multiplayerSetting.maxPlayers)
            {
                readyToStart = true;
                if (PhotonNetwork.IsMasterClient)
                    return;
                PhotonNetwork.CurrentRoom.IsOpen = false;
            }
        }
        else
        {
            StartGame();
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("A new player has joined the room.");
        photonPlayers = PhotonNetwork.PlayerList;
        playersInRoom++;
        if (MultiplayerSettings.multiplayerSetting.delayStart)
        {
            Debug.Log("Displayer players in room out of max player possible (" + playersInRoom + ":" + MultiplayerSettings.multiplayerSetting.maxPlayers + ")");
            if (playersInRoom > 1)
            {
                readyToCount = true;
            }
            if (playersInRoom == MultiplayerSettings.multiplayerSetting.maxPlayers)
            {
                readyToStart = true;
                if (PhotonNetwork.IsMasterClient)
                    return;
                PhotonNetwork.CurrentRoom.IsOpen = false;
            }
        }
    }
    void StartGame()
    {
        isGameLoaded = true;
        if (!PhotonNetwork.IsMasterClient)
            return;
        if (MultiplayerSettings.multiplayerSetting.delayStart)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
        PhotonNetwork.LoadLevel(MultiplayerSettings.multiplayerSetting.multiplayerScene);
    }

    void RestartTimer()
    {
        lessThanMaxPlayers = startingTime;
        timeToStart = startingTime;
        atMaxPlayer = 6;
        readyToCount = false;
        readyToStart = false;
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.buildIndex;
        if(currentScene == MultiplayerSettings.multiplayerSetting.multiplayerScene)
        {
            isGameLoaded = true;
            if (MultiplayerSettings.multiplayerSetting.delayStart)
            {
                PV.RPC("RPC_LoadedGameScene", RpcTarget.MasterClient);
            }
            else
            {
                RPC_CreatePlayer();
            }
        }
    }

    [PunRPC]
    private void RPC_LoadedGameScene()
    {
        playerInGame++;
        if(playerInGame == PhotonNetwork.PlayerList.Length)
        {
            PV.RPC("RPC_CreatePlayer", RpcTarget.All);
        }
    }

    [PunRPC]
    private void RPC_CreatePlayer()
    {
        PhotonNetwork.Instantiate(PlayerPrefs.GetString("MyChar"), transform.position, Quaternion.identity, 0);
    }
}
