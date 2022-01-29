using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkPcPlayer : MonoBehaviour
{
    public GameObject mainCamera;
    public MeshRenderer meshRenderer;
    
    void DisablePlayerController() {
        GetComponent<CharacterController>().enabled = false;
        GetComponent<FpsInputs>().enabled = false;
        GetComponent<FirstPersonController>().enabled = false;
    }
    
    
    void Start()
    {
        if (GetComponent<PhotonView>().IsMine) {
            meshRenderer.enabled = false;
        } else {
            mainCamera.SetActive(false);
            DisablePlayerController();
        }
    }
}
