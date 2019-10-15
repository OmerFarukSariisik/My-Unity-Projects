using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView PV;
    public GameObject myAvatar;
    void Start()
    {
        PV = GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, GameSetup.GS.SpawnPoints.Length);
        if (PV.IsMine)
        {
            myAvatar = PhotonNetwork.Instantiate("Sphere", GameSetup.GS.SpawnPoints[spawnPicker].position,
                GameSetup.GS.SpawnPoints[spawnPicker].rotation, 0);
        }
    }
}
