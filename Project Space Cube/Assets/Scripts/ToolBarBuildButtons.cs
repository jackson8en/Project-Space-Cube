using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolBarBuildButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {

		MouseManager mouseManager = GameObject.FindObjectOfType<MouseManager> ();

		// Populate button list
		foreach (GameObject shipPart in shipPartPrefabs) {
			GameObject buttonGameObject = (GameObject) Instantiate (buildButtonPrefab, this.transform);
			Text buttonLabel = buttonGameObject.GetComponentInChildren<Text> ();
			buttonLabel.text = shipPart.name;

			Button theButton = buttonGameObject.GetComponent<Button> ();

			GameObject shipPartUsed = shipPart;
			theButton.onClick.AddListener (() => {
				mouseManager.spawnObject = shipPartUsed;
			});
		}
	
	}

	public GameObject buildButtonPrefab;
	public GameObject[] shipPartPrefabs;
	
	// Update is called once per frame
	void Update () {
	
	}
}
