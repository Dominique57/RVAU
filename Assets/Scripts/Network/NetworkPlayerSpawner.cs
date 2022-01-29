using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks {
    private GameObject spawnedPlayer;

    public override void OnJoinedRoom() {
        var spawnPosition = transform.position;
        if (Application.platform == RuntimePlatform.Android) {
            spawnPosition.x += 1;
            spawnedPlayer = PhotonNetwork.Instantiate("VR_PlayerController", spawnPosition, transform.rotation);
        } else {
            spawnPosition.x -= 1;
            spawnedPlayer = PhotonNetwork.Instantiate("PC_PlayerController", spawnPosition, transform.rotation);
        }
    }

    public override void OnLeftRoom() {
        PhotonNetwork.Destroy(spawnedPlayer);
    }
}