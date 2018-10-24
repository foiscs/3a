using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Launcher2 : Photon.PunBehaviour
{
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene(1);
    }
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PhotonNetwork.ConnectUsingSettings("1");
        PhotonNetwork.automaticallySyncScene = true;
    }
}
