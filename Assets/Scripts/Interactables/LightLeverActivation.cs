using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LightLeverActivation : MonoBehaviour {
    public ColliderListener enterTrigger;
    public Collider handleCollider;
    
    public GameManager gameManager;

    void Start() {
        enterTrigger.TriggerEnterListener.AddListener(EnterTriggger);
        if (gameManager is null) {
            Debug.LogWarning("Lever missing gameManager, trying to find one");
            gameManager = GameObject.Find("GameManager")?.GetComponent<GameManager>();
        }
    }

    void EnterTriggger(Collider other) {
        if (handleCollider == other)
            PhotonView.Get(this).RPC("OnExecute", RpcTarget.AllBuffered);
    }
    
    [PunRPC]
    void OnExecute(PhotonMessageInfo info) {
        if (gameManager != null && !gameManager.mazeLightEnabled)
            gameManager.enableMazeLight();
    }
}
