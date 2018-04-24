using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public HUDController hudController;
	public GameObject plane = null;
	public GameObject duckPrefab;
	private int levelCount = 0;
	private bool createNewLevel = false;

	public static int numberOfDucks;
	public static bool gameStarted;

	// Use this for initialization
	void Start () {
		hudController = GameObject.Find ("HUD").GetComponent<HUDController> ();
		gameStarted = false;

	}

	void Update() {
		if (createNewLevel) {
			SpawnLevel (levelCount);
			createNewLevel = false;
		}
	}

	public void StartGame() {
		if (plane != null) {
			hudController.RemovePlayButton ();
			hudController.RemoveTrackingText ();
			hudController.ShowGun ();
			hudController.ShowAim ();
			hudController.ShowDuckBar ();

			gameStarted = true; levelCount = 1;
			SpawnLevel (levelCount);
		}
	}

	void SpawnLevel(int numLevel) {
		Transform center = plane.transform;
		hudController.PlayReadyAnimation ();

		for (int i = 0; i < numberOfDucks; i++) {
			Vector3 randomSpawn = new Vector3 (Random.Range(-0.3f, 0.3f), 0.0f, Random.Range(-0.1f, 0.1f));
			Vector3 pos = center.position;
			Quaternion rot = center.rotation;

			GameObject duck = GameObject.Instantiate (duckPrefab, pos, rot);
			duck.transform.Translate (randomSpawn);
		}
	}


	void finishLevel(int numLevel) {
		hudController.ShowRoundText ();
		hudController.roundText.GetComponent<Text> ().text = "Well done!";
		hudController.Wait ();
		levelCount++;
		createNewLevel = true;
	}


}
