using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandColliderHandler : MonoBehaviour
{
    public XRRayInteractor rayInteractor;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.selectEntered.AddListener(OnSelect);
        rayInteractor.selectExited.AddListener(OnDeselect);
    }

    void OnSelect(SelectEnterEventArgs arg)
    {
    }

    void OnDeselect(SelectExitEventArgs arg)
    {
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
