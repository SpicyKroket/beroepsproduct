using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour {
    GameObject playerCam;
    GameObject player;

    Transform currentView;
    Transform playerView;
    public Transform targetView;

    public float transitionSpeed;

    void Start() {
        GameObject playerViewObject = GameObject.Find("Player/Normal view");
        playerView = playerViewObject.GetComponent<Transform>();

        playerCam = GameObject.Find("Character/Player/Main camera");

        currentView = playerView;
    }

    public void goToView(bool viewName) {
        if (viewName) {
            currentView = targetView;
        } else if (!viewName) {
            currentView = playerView;
        }
    }

    void FixedUpdate() {
        if (playerCam.transform.position != currentView.position) {
            //Lerp position
            playerCam.transform.position = Vector3.Lerp(playerCam.transform.position, currentView.position, Time.deltaTime * transitionSpeed);

            Vector3 currentAngle = new Vector3 (
                Mathf.LerpAngle(playerCam.transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
                Mathf.LerpAngle(playerCam.transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
                Mathf.LerpAngle(playerCam.transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed)
                );

            playerCam.transform.eulerAngles = currentAngle;
        }
    }
}
