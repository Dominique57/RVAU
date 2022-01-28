using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlateformManager : MonoBehaviour
{
    public List<GameObject> windowsGameObjects = new List<GameObject>();
    public List<GameObject> androidGameObjects = new List<GameObject>();
    
    void Start()
    {
        switch (Application.platform)
        {
        case RuntimePlatform.Android:
            foreach (var gameObj in windowsGameObjects)
                gameObj.SetActive(false);
            break;
        case RuntimePlatform.WindowsPlayer:
        case RuntimePlatform.WindowsEditor:
            foreach (var gameObj in androidGameObjects)
                gameObj.SetActive(false);
            break;
        default:
            EditorUtility.DisplayDialog("OS ERROR", "Your platform is currently not supported !", "Exit");
            Debug.Log("Leaving application");
            Application.Quit();
            Debug.Log("Left application");
            break;
        }
        
    }

    void Update()
    {
    }
}