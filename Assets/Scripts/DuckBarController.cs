using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DuckBarController : MonoBehaviour {

	private List<GameObject> duckIcons;
	private int aliveDucks;
	public GameObject icon;
	public float iconWidth, iconHeight;
	private float width, height;

	// Use this for initialization
	void Start () {
		duckIcons = new List<GameObject> ();
		width = GetComponent<RectTransform> ().sizeDelta.x;
		height = GetComponent<RectTransform> ().sizeDelta.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.gameStarted && aliveDucks != GameController.numberOfDucks) {
			updateNumberOfDucks (GameController.numberOfDucks);
		}
	}

	public void loadRound(int numberOfDucks) {
		duckIcons.Clear ();
		aliveDucks = numberOfDucks;
		for (int i = 0; i < numberOfDucks; i++) {
			Vector3 position = new Vector3 (iconWidth / 3 + i * iconWidth / 2, transform.position.y, transform.position.z);
			GameObject duckIcon = Instantiate (icon, position, Quaternion.identity);
			duckIcon.transform.parent = gameObject.transform;

			duckIcons.Add (duckIcon);

			DuckIconController controller = duckIcons [i].GetComponent<DuckIconController> ();
			controller.turnOn ();

		}
	}

	public void updateNumberOfDucks(int newNumberOfDucks) {
		aliveDucks = Math.Max(newNumberOfDucks, 0);
		for (int i = 0; i < duckIcons.Count; i++) {
			DuckIconController controller = duckIcons [i].GetComponent<DuckIconController> ();
			if (i >= aliveDucks) {
				controller.turnOff ();
			} else {
				controller.turnOn ();
			}
		}
	}
}
