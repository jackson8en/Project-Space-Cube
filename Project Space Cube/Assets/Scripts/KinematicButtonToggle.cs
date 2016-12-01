using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KinematicButtonToggle : MonoBehaviour {
	public Button button;
	public Rigidbody shipRB;
	public bool buttonOn = false;
	public Text buttonText;

	public void SetColor(){
		if (buttonOn == false) {
			this.GetComponent<Image> ().color = Color.green;
			buttonText.color = Color.black;
			shipRB.isKinematic = false;
			buttonOn = true;
		} else if (buttonOn == true) {
			this.GetComponent<Image> ().color = Color.red;
			buttonText.color = Color.white;
			shipRB.isKinematic = true;
			buttonOn = false;
		}
	}
}
