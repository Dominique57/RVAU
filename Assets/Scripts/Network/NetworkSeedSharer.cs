using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = System.Random;

public class NetworkSeedSharer : MonoBehaviourPunCallbacks {
    
    public int seed = 42;
    public bool randomSeed = false;
    public GameObject mazeSpawnerObject;

    private PhotonView _photonView;
    private MazeSpawner mazeSpawner;
    
    void Start() {
        _photonView = PhotonView.Get(this);
        mazeSpawner = mazeSpawnerObject.GetComponent<MazeSpawner>();
        if (randomSeed) {
            seed = new Random().Next(Int32.MaxValue);
            Debug.LogWarning($"seed is {seed}");
        }
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer) {
        if (PhotonNetwork.IsMasterClient)
            _photonView.RPC("ShareMazeSeed", newPlayer, seed);
    }

    [PunRPC]
    void ShareMazeSeed(int mazeSeed, PhotonMessageInfo info) {
        mazeSpawner.FullRandom = false;
        mazeSpawner.RandomSeed = mazeSeed;
        mazeSpawnerObject.SetActive(true);
    }
    
    public override void OnJoinedRoom() {
        if (PhotonNetwork.IsMasterClient) {
            mazeSpawner.FullRandom = false;
            mazeSpawner.RandomSeed = seed;
            mazeSpawnerObject.SetActive(true);
        }
    }
}
