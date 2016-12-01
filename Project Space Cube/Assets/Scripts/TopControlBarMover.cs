using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TopControlBarMover : MonoBehaviour {
	bool displayOpen = false;
	public Text arrow;

	public void DisplayToggle(){
		if (displayOpen == false) {
			transform.Translate(new Vector3 (0, -100, 0));
			arrow.text = "^";
			displayOpen = true;
		} else if (displayOpen == true) {
			transform.Translate(new Vector3 (0, 100, 0));
			arrow.text = "v";
			displayOpen = false;
		}
	}
}
