using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public GameObject spawnObject;
	public LayerMask snapPointLayerMask;

	// Update is called once per frame
	void Update () {
		// Was the mouse pressed down this frame
		if(Input.GetMouseButtonDown(0)){ 
			// Left mouse button was pressed
			// Is the mouse over an object
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;

			if (Physics.Raycast (ray, out hitInfo)) {
				// Was the click on a SnapPoint
				// SnapPoints are always on the SnapPoint physics layer
				int maskHitObject = 1 << hitInfo.collider.gameObject.layer;
				if((maskHitObject & snapPointLayerMask) != 0){
					// Spawn new object
					Vector3 spawnLocation = hitInfo.collider.transform.position + hitInfo.normal;
					Quaternion spawnRotation = Quaternion.FromToRotation (Vector3.forward, hitInfo.normal);

					Instantiate(spawnObject, spawnLocation, spawnRotation);
				}
			}
		}
	}
		
}