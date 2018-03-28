using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public HUDController hudController;

	// Use this for initialization
	void Start () {
		hudController = GameObject.Find ("HUD").GetComponent<HUDController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame() {
		hudController.gameStarted = true;
		hudController.RemovePlayButton ();
		hudController.RemoveTrackingText ();
	}
}
