using UnityEngine;
using System.Collections;

public class HUDRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //get the camera's forward direction from here
        Camera camera = transform.parent.GetComponentInChildren<Camera>();
        Vector3 cameraForward = camera.transform.forward;

        //get the horizontal projected vector from the camera
        Vector3 projetedCameraForward = Vector3.ProjectOnPlane(cameraForward, Vector3.up);
        
        //set the pivot's rotation to move the HUD
        transform.rotation = Quaternion.LookRotation(projetedCameraForward, Vector3.up);

	}
}
