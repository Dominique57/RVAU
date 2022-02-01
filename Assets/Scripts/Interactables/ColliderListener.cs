using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ColliderListener : MonoBehaviour {

    private UnityEvent<Collider> triggerEnterListener = new UnityEvent<Collider>();
    private UnityEvent<Collider> triggerExitListener = new UnityEvent<Collider>();
    
    public UnityEvent<Collider> TriggerEnterListener => triggerEnterListener;
    public UnityEvent<Collider> TriggerExitListener => triggerExitListener;

    // Start is called before the first frame update
    void Start() {
    }

    private void OnTriggerEnter(Collider other) {
        triggerEnterListener.Invoke(other);
    }

    private void OnTriggerExit(Collider other) {
        triggerExitListener.Invoke(other);
    }
}
