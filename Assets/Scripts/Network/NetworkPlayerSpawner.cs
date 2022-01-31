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

    public GameObject mazeCeiling;
    
    public GameManager gameManager;

    public override void OnJoinedRoom() {
        if (Application.platform == RuntimePlatform.Android) {
            spawnedPlayer = PhotonNetwork.Instantiate("VR_PlayerController", VRSpawner.transform.position, transform.rotation);
            mazeCeiling.SetActive(true);
            gameManager.toggleFlashLights();
        } else {
            spawnedPlayer = PhotonNetwork.Instantiate("PC_PlayerController", PCSpawner.transform.position, transform.rotation);
            mazeCeiling.SetActive(false);
            gameManager.toggleFlashLights();
        }
    }

    public override void OnLeftRoom() {
        PhotonNetwork.Destroy(spawnedPlayer);
    }
}