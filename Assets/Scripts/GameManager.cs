using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour {
    
    public bool mazeLightEnabled = false;
    public Color noLightColor;
    public Color lightColor;
    public DoorOpeningWithLock lightStepDoor;

    public bool greenDoorUnlocked = false;
    public ColliderListener greenBadgeCollider;
    public DoorOpeningWithLock greenBadgeStepDoor;

    public LeverActivation leverDoor1;
    public LeverActivation leverDoor2;
    public LeverActivation leverDoor3;
    public bool leverCodeCorrect = false;
    public List<DoorOpeningWithLock> leverStepDoors = new List<DoorOpeningWithLock>();

    protected struct LeverCode {
        public LeverActivation _lever;
        public bool _enabled; // true => Enabled // false => Disabled
        public LeverCode(LeverActivation lever, bool enabled) {
            _lever = lever;
            _enabled = enabled;
        }
    }
    protected List<LeverCode> _leverCodes = new List<LeverCode>();
    
    // Start is called before the first frame update
    void Start()
    {
        if (!mazeLightEnabled)
            disableMazeLight();
        else
            enableMazeLight();

        greenBadgeStepDoor.locked = !greenDoorUnlocked;
        
        greenBadgeCollider.TriggerEnterListener.AddListener(OnGreenTriggerEnter);
        leverDoor1.EnableEvent.AddListener(OnLeverDoorToggle);
        leverDoor1.DisableEvent.AddListener(OnLeverDoorToggle);
        leverDoor2.EnableEvent.AddListener(OnLeverDoorToggle);
        leverDoor2.DisableEvent.AddListener(OnLeverDoorToggle);
        leverDoor3.EnableEvent.AddListener(OnLeverDoorToggle);
        leverDoor3.DisableEvent.AddListener(OnLeverDoorToggle);

        _leverCodes.Clear();
        _leverCodes.Add(new LeverCode(leverDoor1, true));
        _leverCodes.Add(new LeverCode(leverDoor2, true));
        _leverCodes.Add(new LeverCode(leverDoor3, false));
        
        if (leverCodeCorrect)
            OnLeverCodeCorrect();
    }

    // Called only in editor mode when a variable is changed
    private void OnValidate() {
        Start();
    }

    public void disableMazeLight() {
        mazeLightEnabled = false;

        toggleFlashLights(true);

        RenderSettings.ambientLight = noLightColor;
    }
    
    public void enableMazeLight() {
        mazeLightEnabled = true;
        
        toggleFlashLights(false);
        lightStepDoor.locked = false;
        
        RenderSettings.ambientLight = lightColor;
    }

    public void toggleFlashLights(bool active) {
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Flashlight")) {
            if (gameObj.GetComponent<Light>() is var _light && _light != null)
                _light.enabled = active;
        } 
    }

    public void toggleFlashLights() {
        toggleFlashLights(!mazeLightEnabled);
    }

    public void OnGreenTriggerEnter(Collider other) {
        if (other.CompareTag("Badge"))
            greenBadgeStepDoor.locked = false;
    }

    
    public String LevelCodeToString() {
        var builder = new StringBuilder();
        foreach (var leverCode in _leverCodes) {
            if (leverCode._enabled) {
                builder.Append(leverCode._lever.Enabled? "OK": "KO");
            } else {
                builder.Append(leverCode._lever.Disabled? "OK": "KO");
            }
            builder.Append(" ");
        }
        return builder.ToString();
    }
    
    public bool CheckLevelCode() {
        foreach (var leverCode in _leverCodes) {
            if (leverCode._enabled) {
                if (!leverCode._lever.Enabled)
                    return false;
            } else {
                if (!leverCode._lever.Disabled)
                    return false;
            }
        }
        return true;
    }
    
    protected void OnLeverDoorToggle(Collider other) {
        leverCodeCorrect = CheckLevelCode();
        Debug.Log($"Lever activated: correct code: {leverCodeCorrect}, repr: {LevelCodeToString()}");
        if (leverCodeCorrect)
            OnLeverCodeCorrect();
    }

    public void OnLeverCodeCorrect() {
        foreach (var leverStepDoor in leverStepDoors) {
            leverStepDoor.locked = false;
        }
    }
}
