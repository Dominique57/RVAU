using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public Animator animator;

    private static readonly int CharacterNearby = Animator.StringToHash("character_nearby");

    // Start is called before the first frame update
    void Start() {
        SphereCollider sphereCollider = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        sphereCollider.isTrigger = true;
        sphereCollider.center = new Vector3(-1.2f, 2, 0);
        sphereCollider.radius = 3.5f;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            animator.SetBool(CharacterNearby, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            animator.SetBool(CharacterNearby, false);
        }
    } 
}
