using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RotateButtonToggle : MonoBehaviour {

	public Button button;
	public CameraManager cm;
	public bool buttonOn = false;
	public Text buttonText;

	public void SetColor(){
		if (buttonOn == false) {
			this.GetComponent<Image> ().color = Color.green;
			buttonText.color = Color.black;
			cm.orbitAllowed = true;
			buttonOn = true;
		} else if (buttonOn == true) {
			this.GetComponent<Image> ().color = Color.red;
			buttonText.color = Color.white;
			cm.orbitAllowed = false;
			buttonOn = false;
		}
	}
}
