using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningWithLock : MonoBehaviour {
    public Animator animator;
    public bool locked = true;

    private static readonly int CharacterNearby = Animator.StringToHash("character_nearby");

    void Start() {
        SphereCollider sphereCollider = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        sphereCollider.isTrigger = true;
        sphereCollider.center = new Vector3(-1.2f, 2, 0);
        sphereCollider.radius = 3.5f;
    }

    private static bool isPlayer(Collider other) {
        return other.gameObject.tag.Equals("VR_Player") ||
               other.gameObject.tag.Equals("PC_Player");
    }

    private void OnTriggerEnter(Collider other) {
        if (isPlayer(other) && !locked)
            animator.SetBool(CharacterNearby, true);
    }

    private void OnTriggerExit(Collider other) {
        if (isPlayer(other))
            animator.SetBool(CharacterNearby, false);
    }
}