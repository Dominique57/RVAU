using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkPcPlayer : MonoBehaviour
{
    public GameObject mainCamera;
    
    void DisablePlayerController() {
        GetComponent<CharacterController>().enabled = false;
        GetComponent<FpsInputs>().enabled = false;
        GetComponent<FirstPersonController>().enabled = false;
    }
    
    
    void Start()
    {
        if (!GetComponent<PhotonView>().IsMine) {
            mainCamera.SetActive(false);
            DisablePlayerController();
        }
    }
}
