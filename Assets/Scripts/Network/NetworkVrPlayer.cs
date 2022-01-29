using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkVrPlayer : MonoBehaviour {

    public GameObject cameraOffset;
    public GameObject mainCamera;
    public GameObject lHandController;
    public GameObject rHandController;
    public GameObject lHandPrefab;
    public GameObject rHandPrefab;

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
        handController.GetComponent<XRRayInteractor>().enabled = false;
        handController.GetComponent<LineRenderer>().enabled = false;
        handController.GetComponent<XRInteractorLineVisual>().enabled = false;
    }

    void DisableHandPrefab(GameObject handPrefab) {
        handPrefab.GetComponent<HandAnimRxi>().enabled = false;
        handPrefab.GetComponent<HandColliderHandler>().enabled = false;
    }
    
    void Start() {
        if (!GetComponent<PhotonView>().IsMine) {
            cameraOffset.transform.position += Vector3.up * GetComponent<XROrigin>().CameraYOffset;
            mainCamera.SetActive(false);
            DisablePlayerController();
            DisableHandController(lHandController);
            DisableHandController(rHandController);
            DisableHandPrefab(lHandPrefab);
            DisableHandPrefab(rHandPrefab);
        }
    }
}
