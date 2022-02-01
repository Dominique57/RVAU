using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.LowLevel;

public class LeverActivation : MonoBehaviour {
    public ColliderListener enableTrigger;
    public ColliderListener disableTrigger;
    public Collider handleCollider;

    private UnityEvent<Collider> enableEvent = new UnityEvent<Collider>();
    private UnityEvent<Collider> disableEvent = new UnityEvent<Collider>();
    
    public UnityEvent<Collider> EnableEvent => enableEvent;
    public UnityEvent<Collider> DisableEvent => disableEvent;

    protected bool m_enabled = false;
    protected bool m_disabled = false;

    public bool Enabled => m_enabled;
    public bool Disabled => m_disabled;
    
    void Start() {
        enableTrigger.TriggerEnterListener.AddListener(EnableLeverEnter);
        enableTrigger.TriggerExitListener.AddListener(EnableLeverExit);
        disableTrigger.TriggerEnterListener.AddListener(DisableLeverEnter);
        disableTrigger.TriggerExitListener.AddListener(DisableLeverExit);
    }

    void EnableLeverEnter(Collider other) {
        if (other != handleCollider)
            return;
        
        m_enabled = true;
        enableEvent.Invoke(other);
    }
    
    void EnableLeverExit(Collider other) {
        if (other != handleCollider)
            return;
        
        m_enabled = false;
    }

    void DisableLeverEnter(Collider other) {
        if (other != handleCollider)
            return;

        m_disabled = true;
        disableEvent.Invoke(other);
    }
    
    void DisableLeverExit(Collider other) {
        if (other != handleCollider)
            return;
        
        m_disabled = false;
    }
}
