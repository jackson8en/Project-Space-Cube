using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		shipRigidbody = this.transform.root.GetComponent<Rigidbody> ();
	}

	float ThrusterStrength = 10f;
	Rigidbody shipRigidbody;

	void FixedUpdate(){

		if (shipRigidbody.isKinematic) {
			return;
		} else {
		
			if (Input.GetMouseButton(0)) {
				Vector3 theForce = - this.transform.forward * ThrusterStrength;
				shipRigidbody.AddForceAtPosition ( theForce, this.transform.position);
			}		
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
