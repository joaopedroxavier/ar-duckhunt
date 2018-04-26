using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public HUDController hudController;
	public GameObject plane = null;
	public GameObject duckPrefab;
	public static int levelCount = 0;
	private float roundStartTime;
	private int currentSpawn = 0;

	public static int numberOfDucks;
	public static bool gameStarted;

	private List<float> spawnTimers;

	// Use this for initialization
	void Start () {
		hudController = GameObject.Find ("HUD").GetComponent<HUDController> ();
		gameStarted = false; 
		currentSpawn = 0;
		spawnTimers = new List<float>();
	}

	void Update() {
		if (gameStarted && currentSpawn < spawnTimers.Count) {
			if (Time.time > roundStartTime + spawnTimers [currentSpawn]) {
				currentSpawn++;
				SpawnDuck ();
			}
		}
		if (gameStarted && numberOfDucks == 0) {
			numberOfDucks = -1;
			finishLevel ();
		}
		if (gameStarted) {
			hudController.RemovePlayButton ();
		}
	}

	public void StartGame() {
		if (plane != null) {
			hudController.RemovePlayButton ();
			hudController.RemoveTrackingText ();
			hudController.ShowGun ();
			hudController.ShowAim ();
			hudController.ShowDuckBar ();
			hudController.ShowScore ();

			levelCount = 1;
			SpawnLevel (levelCount);
		}
	}

	void SpawnLevel(int numLevel) {
		numberOfDucks = (numLevel / 5) + 3;
		Debug.Log ("Going to animate!");
		if (!gameStarted)
			StartCoroutine (Animate ());
		else {
			StartCoroutine (AnimateRestart ());
		}
	}

	void SpawnDuck() {
		Debug.Log ("I spawned a duck! " + Time.time);
		Transform center = plane.transform;
		Vector3 randomSpawn = new Vector3 (Random.Range(-0.3f, 0.3f), 0.0f, Random.Range(-0.1f, 0.1f));
		Vector3 pos = center.position;
		Quaternion rot = center.rotation;

		GameObject duck = GameObject.Instantiate (duckPrefab, pos, rot);
		duck.transform.Translate (randomSpawn);
	}

	IEnumerator Animate() {
		hudController.PlayReadyAnimation ();
		yield return new WaitForSeconds(3.0f);
		Debug.Log ("Finished waiting");
		LoadSpawns ();
	}

	IEnumerator AnimateRestart() {
		hudController.PlayWellDoneAnimation ();
		yield return new WaitForSeconds (4.0f);
		LoadSpawns ();
	}

	void LoadSpawns() {
		Debug.Log ("Cheguei ate aqui2");
		spawnTimers.Clear ();
		Debug.Log ("Cheguei ate aqui");
		for (int i = 0; i < numberOfDucks; i++) {
			spawnTimers.Add(Random.Range (1.0f, 10.0f));
		}
		spawnTimers.Sort ();
		currentSpawn = 0;
		roundStartTime = Time.time;
		gameStarted = true;
		hudController.loadRound (numberOfDucks);
	}

	void finishLevel() {
		levelCount++;
		SpawnLevel (levelCount);
	}


}
