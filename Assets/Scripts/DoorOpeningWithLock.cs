using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class DoorOpeningWithLock : MonoBehaviour {
    public Animator animator;
    public bool locked = true;

    private static readonly int CharacterNearby = Animator.StringToHash("character_nearby");

    void Start() {
        BoxCollider boxCollider = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        boxCollider.isTrigger = true;
        boxCollider.center = new Vector3(0, 2, 0);
        boxCollider.size = new Vector3(4, 4, 6);
    }

    private static bool isPlayer(Collider other) {
        return other.gameObject.tag.Equals("VR_Player") ||
               other.gameObject.tag.Equals("PC_Player");
    }

    private void OnTriggerEnter(Collider other) {
        if (!isPlayer(other) || locked)
            return;
        
        var photonView = PhotonView.Get(this);
        if (photonView != null)
            photonView.RequestOwnership();

        animator.SetBool(CharacterNearby, true);
    }

    private void OnTriggerExit(Collider other) {
        if (!isPlayer(other))
            return;
        
        var photonView = PhotonView.Get(this);
        if (photonView != null)
            photonView.RequestOwnership();

        animator.SetBool(CharacterNearby, false);
    }
}