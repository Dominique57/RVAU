using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LeverActivation : MonoBehaviour {
    public float rotationTriggerLimit = -177;
    public float rotationTriggerOffset = 5;

    private float rotationMin;
    private float rotationMax;
    
    // Start is called before the first frame update
    void Start() {
        rotationMin = rotationTriggerLimit - rotationTriggerOffset;
        rotationMax = rotationTriggerLimit + rotationTriggerOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotationMin < transform.rotation.x && transform.rotation.x < rotationMax) {
            PhotonView.Get(this).RPC("OnExecute", RpcTarget.All);
        }
    }

    [PunRPC]
    void OnExecute(PhotonMessageInfo info) {
        
    }
}
