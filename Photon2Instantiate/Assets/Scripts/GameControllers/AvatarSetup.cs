using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{

    private PhotonView PV;
    public GameObject myCharacter;
    public int characterValue;
    private void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, PlayerInfo.PI.mySelectedChar);
        }
    }

    [PunRPC]
    void RPC_AddCharacter(int which)
    {
        characterValue = which;
        myCharacter = Instantiate(PlayerInfo.PI.allChars[which], transform.position, transform.rotation, transform);
    }
}
