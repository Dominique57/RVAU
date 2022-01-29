using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks {
    private GameObject spawnedPlayer;
    public GameObject PCSpawner;
    public GameObject VRSpawner;

    public override void OnJoinedRoom() {
        if (Application.platform == RuntimePlatform.Android) {
            spawnedPlayer = PhotonNetwork.Instantiate("VR_PlayerController", VRSpawner.transform.position, transform.rotation);
        } else {
            spawnedPlayer = PhotonNetwork.Instantiate("PC_PlayerController", PCSpawner.transform.position, transform.rotation);
        }
    }

    public override void OnLeftRoom() {
        PhotonNetwork.Destroy(spawnedPlayer);
    }
}