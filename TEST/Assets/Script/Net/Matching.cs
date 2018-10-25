using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Matching : Photon.PunBehaviour
{
    public byte MaxPlayer = 4;

    void Start()
    {

    }

    void Update()
    {
        if(PhotonNetwork.inRoom)
        {
            if(PhotonNetwork.room.PlayerCount == MaxPlayer)
            {
                if (PhotonNetwork.isMasterClient)
                    PhotonNetwork.LoadLevel(2);
            }
        }
    }

    public void ChangeMode(int Player)
    {
        MaxPlayer = Convert.ToByte(Player);
    }

    public void ButtenClick()
    {
        PhotonNetwork.JoinRandomRoom(null, MaxPlayer); 
    }
    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
            PhotonNetwork.CreateRoom(null, new RoomOptions
            {
                MaxPlayers = MaxPlayer
            }, TypedLobby.Default);
    }
}
