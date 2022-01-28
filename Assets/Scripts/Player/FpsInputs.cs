using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsInputs : MonoBehaviour {
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;

    [Header("Movement Settings")]
    public bool analogMovement;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;

    private void Update() {
        var newMove = new Vector2();
        if (Input.GetKey(KeyCode.W))
            newMove.y += 1;
        if (Input.GetKey(KeyCode.S))
            newMove.y -= 1;
        if (Input.GetKey(KeyCode.D))
            newMove.x += 1;
        if (Input.GetKey(KeyCode.A))
            newMove.x -= 1;
        move = newMove.normalized;

        look = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        jump = Input.GetKey(KeyCode.Space);
        sprint = Input.GetKey(KeyCode.LeftShift);
    }

    private void OnApplicationFocus(bool hasFocus) {
        SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool newState) {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}