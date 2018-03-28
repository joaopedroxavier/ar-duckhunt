﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

	public HUDController hudController;
	public GameObject plane = null;
	public GameObject duckPrefab;
	private int levelCount = 0;

	public static int numberOfDucks;
	public static bool gameStarted;

	// Use this for initialization
	void Start () {
		hudController = GameObject.Find ("HUD").GetComponent<HUDController> ();
		gameStarted = false;
	}

	void Update() {
		if (gameStarted && numberOfDucks == 0) {
			levelCount++;
			SpawnLevel (levelCount);
		}
	}

	public void StartGame() {
		if (plane != null) {
			hudController.RemovePlayButton ();
			hudController.RemoveTrackingText ();
			hudController.ShowGun ();
			hudController.ShowAim ();

			gameStarted = true; levelCount = 1;
			SpawnLevel (levelCount);
		}
	}

	void SpawnLevel(int numLevel) {
		Transform center = plane.transform;

		numberOfDucks = (numLevel / 10) + 2;
		for (int i = 0; i < numberOfDucks; i++) {
			Vector3 randomSpawn = new Vector3 (Random.Range(-0.3f, 0.3f), 0.0f, Random.Range(-0.1f, 0.1f));
			Transform transform = center;
			transform.Translate (randomSpawn, Space.Self);

			GameObject.Instantiate (duckPrefab, transform);
		}
	}


}
