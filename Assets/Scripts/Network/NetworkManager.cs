using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Debug.Log("Connecting to PUN...");

        // Settings
        DontDestroyOnLoad(this.gameObject);
        PhotonNetwork.AutomaticallySyncScene = true;

        // Network room
        PhotonNetwork.ConnectUsingSettings();
    }

    void Update()
    {
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to PUN !");

        var roomOptions = new RoomOptions
        {
            IsVisible = false
        };
        PhotonNetwork.JoinOrCreateRoom("master", roomOptions, null);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Create room failed: code: {returnCode}, message: {message}");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Join room failed: code: {returnCode}, message: {message}");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room !");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player joined room !");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player left room !");
    }
}