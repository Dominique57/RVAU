using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour {
    
    public bool mazeLightEnabled = false;
    public Color noLightColor;
    public Color lightColor;

    // Start is called before the first frame update
    void Start()
    {
        if (!mazeLightEnabled)
            disableMazeLight();
        else
            enableMazeLight();
    }

    // Called only in editor mode when a variable is changed
    private void OnValidate() {
        Start();
    }

    public void disableMazeLight() {
        mazeLightEnabled = false;

        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Flashlight")) {
            if (gameObj.GetComponent<Light>() is var _light && _light != null)
                _light.enabled = true;
        }

        RenderSettings.ambientLight = noLightColor;
    }
    
    public void enableMazeLight() {
        mazeLightEnabled = true;
        
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Flashlight")) {
            if (gameObj.GetComponent<Light>() is var _light && _light != null)
                _light.enabled = false;
        }
        
        RenderSettings.ambientLight = lightColor;
    }
}
