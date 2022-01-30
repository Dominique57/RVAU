using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public Animator animator;

    private static readonly int CharacterNearby = Animator.StringToHash("character_nearby");

    private BoxCollider boxCollider;

    private GameObject player = null;

    // Start is called before the first frame update
    void Start() {
        SphereCollider sphereCollider = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        sphereCollider.isTrigger = true;
        sphereCollider.center = new Vector3(-1.2f, 2, -1);
        sphereCollider.radius = 2.5f;

        boxCollider = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        boxCollider.center = new Vector3(0, 2, 0.15f);
        boxCollider.size = new Vector3(4, 4, 0.3f);
        boxCollider.enabled = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!boxCollider.enabled && other.gameObject.tag.Equals("PC_Player")) // TODO: replace to VR_Player
        {
            animator.SetBool(CharacterNearby, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("PC_Player")) // TODO: replace to VR_Player
        {
            animator.SetBool(CharacterNearby, false);

            if (player == null)
                player = GameObject.FindWithTag("PC_Player"); // TODO: replace to VR_player

            if (gameObject.transform.position.z < player.transform.position.z)
                boxCollider.enabled = true;
        }
    } 
}
