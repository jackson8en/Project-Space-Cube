using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (theCamera == null) {
			// Check components
			theCamera = GetComponent<Camera>();
		}

		if (theCamera == null) {
			// Is there a main camera
			theCamera = Camera.main;
		}

		if (theCamera == null) {
			Debug.LogError ("Could not find a camera.");
			return;
		}

		cameraRig = theCamera.transform.parent;
	}
		
	public Camera theCamera;

	private Transform cameraRig;

	private Vector3 previousMousePos;

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (1) == true) {
			// Mouse down this frame
			previousMousePos = Input.mousePosition;
		}

		if (Input.GetMouseButton (1) == true) {
			// Holding down Right-Mouse Button

			// Current mouse position is...
			Vector3 currentMousePos = Input.mousePosition;

			// In pixels
			Vector3 mouseMovement = currentMousePos - previousMousePos;

			// Orbit camera rig around focal point
			Vector3 posRelativeToRig = theCamera.transform.localPosition;

			Vector3 rotationAngles = mouseMovement / 10;

			Quaternion theRotation = Quaternion.Euler(rotationAngles.y, rotationAngles.x, 0);

			posRelativeToRig = theRotation * posRelativeToRig;
			theCamera.transform.localPosition = posRelativeToRig;

			previousMousePos = currentMousePos;
		}
	}
}
