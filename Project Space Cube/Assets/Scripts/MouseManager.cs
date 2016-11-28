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
					Vector3 spawnLocation = hitInfo.collider.transform.position;
					Quaternion spawnRotation = hitInfo.collider.transform.rotation;
					Transform spawnParent = hitInfo.collider.transform;

					GameObject spawnChild = (GameObject) Instantiate(spawnObject, spawnLocation, spawnRotation);
					spawnChild.transform.SetParent (spawnParent);

					//Disable renderer on snapPoint when object is attached
					if(hitInfo.collider.GetComponent<Renderer>() != null){
						hitInfo.collider.GetComponent<Renderer> ().enabled = false;
					}
					if(hitInfo.collider.GetComponent<Collider>() != null){
						hitInfo.collider.GetComponent<Collider> ().enabled = false;
					}
				}
			}
		}
	}

//	void RemovePart(GameObject go){
//		//Re-enable the snap point go is attached to
//		go.transform.parent.GetComponent<Renderer>() = true;
//		go.transform.parent.GetComponent<Collider>() = true;
//	}
		
}