using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(XRGrabInteractable))]
public class XRNetworkGrabInteractable : MonoBehaviour {
    
    private PhotonView _photonView;
    // Start is called before the first frame update
    void Start() {
        _photonView = GetComponent<PhotonView>();
        if (_photonView.OwnershipTransfer != OwnershipOption.Takeover) {
            Debug.LogWarning("Ownership Transfer should be Takeover !");
            _photonView.OwnershipTransfer = OwnershipOption.Takeover;
        }
        
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnSelected);
    }

    void OnSelected(SelectEnterEventArgs arg) {
        _photonView.RequestOwnership();
    }
}
