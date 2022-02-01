using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(XRGrabInteractable))]
public class XRNetworkGrabInteractable : MonoBehaviour {
    
    private PhotonView _photonView;
    private Rigidbody _rigidbody;
    private bool useGravityBackup = false;
    
    
    void Start() {
        _photonView = GetComponent<PhotonView>();
        _rigidbody = GetComponent<Rigidbody>();
        useGravityBackup = _rigidbody.useGravity;
        
        if (_photonView.OwnershipTransfer != OwnershipOption.Takeover) {
            Debug.LogWarning("Ownership Transfer should be Takeover !");
            _photonView.OwnershipTransfer = OwnershipOption.Takeover;
        }
        
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnSelected);
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnExited);
    }

    void OnSelected(SelectEnterEventArgs arg) {
        PhotonView.Get(this).RPC("setGravity", RpcTarget.All, false);
        
        _photonView.RequestOwnership();
    }

    void OnExited(SelectExitEventArgs arg) {
        PhotonView.Get(this).RPC("setGravity", RpcTarget.All, useGravityBackup);
    }

    [PunRPC]
    void setGravity(bool useGravity, PhotonMessageInfo info) {
        _rigidbody.useGravity = useGravity;
    }
}
