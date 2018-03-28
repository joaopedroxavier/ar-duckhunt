using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	public Button playButton;
	public Text trackingPhaseText;

	public bool gameStarted;
	// Use this for initialization
	void Start () {
		RemovePlayButton ();

		gameStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RemoveTrackingText() {
		trackingPhaseText.gameObject.SetActive (false);
	}

	public void EnablePlayButton() {
		playButton.gameObject.SetActive (true);
	}

	public void RemovePlayButton() {
		playButton.gameObject.SetActive (false);
	}
}
