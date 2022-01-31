using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ColliderListener : MonoBehaviour {

    private UnityEvent<Collider> triggerEnterListener;
    private UnityEvent<Collider> triggerExitListener;
    
    public UnityEvent<Collider> TriggerEnterListener => triggerEnterListener;
    public UnityEvent<Collider> TriggerExitListener => triggerExitListener;

    // Start is called before the first frame update
    void Start() {
        triggerEnterListener = new UnityEvent<Collider>();
        triggerExitListener = new UnityEvent<Collider>();
    }

    private void OnTriggerEnter(Collider other) {
        triggerEnterListener.Invoke(other);
    }

    private void OnTriggerExit(Collider other) {
        triggerExitListener.Invoke(other);
    }
}
