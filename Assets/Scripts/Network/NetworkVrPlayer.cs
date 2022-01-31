using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
using XRController = UnityEngine.XR.Interaction.Toolkit.XRController;

public class NetworkVrPlayer : MonoBehaviour {

    public GameObject cameraOffset;
    public MeshRenderer meshRenderer;
    public GameObject mainCamera;
    public GameObject lHandController;
    public GameObject rHandController;
    public GameObject lHandPrefab;
    public GameObject rHandPrefab;

    void DisableCamera() {
        mainCamera.GetComponent<Camera>().enabled = false;
        mainCamera.GetComponent<AudioListener>().enabled = false;
        // TODO: disable TrackedPoseDriver
    }
    
    void DisablePlayerController() {
        GetComponent<XROrigin>().enabled = false;
        GetComponent<LocomotionSystem>().enabled = false;
        GetComponent<DeviceBasedSnapTurnProvider>().enabled = false;
        GetComponent<DeviceBasedContinuousMoveProvider>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<CharacterControllerDriver>().enabled = false;
    }

    void DisableHandController(GameObject handController) {
        handController.GetComponent<XRController>().enabled = false;
        handController.GetComponent<XRDirectInteractor>().enabled = false;
        handController.GetComponent<CapsuleCollider>().enabled = false;
    }

    void DisableHandPrefab(GameObject handPrefab) {
        handPrefab.GetComponent<HandAnimRxi>().enabled = false;
    }
    
    void Start() {
        if (GetComponent<PhotonView>().IsMine) {
            meshRenderer.enabled = false;
        } else {
            cameraOffset.transform.position += Vector3.up * GetComponent<XROrigin>().CameraYOffset;
            DisableCamera();
            DisablePlayerController();
            DisableHandController(lHandController);
            DisableHandController(rHandController);
            DisableHandPrefab(lHandPrefab);
            DisableHandPrefab(rHandPrefab);
        }
    }
}
