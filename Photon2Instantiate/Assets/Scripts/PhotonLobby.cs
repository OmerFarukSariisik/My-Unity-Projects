using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    public GameObject battleButton;
    public GameObject cancelButton;
    private void Awake()
    {
        lobby = this;
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true);
    }
    public void OnBattleButtonClick()
    {
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("FAİLED TO JOİN");
        CreateRoom();
    }

    void CreateRoom()
    {
        int randomRoom = Random.Range(0, 10000);
        RoomOptions r = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)MultiplayerSettings.multiplayerSetting.maxPlayers };
        PhotonNetwork.CreateRoom("Room" + randomRoom, r);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed cause already have that name of room.");
        CreateRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        PlayerInfo.PI.team = '1';
    }

    public void OnCancelButtonClick()
    {
        battleButton.SetActive(true);
        cancelButton.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }
}
