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

	public float orbitSensitivity = 4;

	public float zoomMultiplier = 2;
	public float minDist = 2;
	public float maxDist = 25;

	float panSpeed = 1;

	void Update(){
		OrbitCamera ();
		DollyCamera ();
	}

	void DollyCamera(){
		float delta = - Input.GetAxis ("Mouse ScrollWheel");

		//Move camera forwards or backwards
		Vector3 actualChange = theCamera.transform.localPosition * zoomMultiplier * delta;
		Vector3 newPos = theCamera.transform.localPosition + actualChange;
		newPos = newPos.normalized * Mathf.Clamp (newPos.magnitude, minDist, maxDist);
		theCamera.transform.localPosition = newPos;
	}

	// Update is called once per frame
	void OrbitCamera () {

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

			Vector3 rotationAngles = mouseMovement * orbitSensitivity * Time.deltaTime;

			// TODO: Fix me
			//Quaternion theRotation = Quaternion.Euler(rotationAngles.y, rotationAngles.x, 0);

			//posRelativeToRig = theRotation * posRelativeToRig;
			//theCamera.transform.localPosition = posRelativeToRig;

			theCamera.transform.RotateAround (cameraRig.transform.position, theCamera.transform.right, rotationAngles.y);
			theCamera.transform.RotateAround (cameraRig.position, theCamera.transform.up, rotationAngles.x);

			// Correct camera viewpoint to focal
			Quaternion lookRotation = Quaternion.LookRotation( - theCamera.transform.localPosition);
			theCamera.transform.rotation = lookRotation;

		}
	}
}
