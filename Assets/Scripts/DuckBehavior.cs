using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBehavior : MonoBehaviour {

	// Use this for initialization

	private Vector3 velocity;
	private float speed;
	public PathGenerator path;
	Vector3 targetWayPoint;
	int current = 0;
	float birthTime;
	bool turned = false;
	Vector3 verticalOscillation;

	void Start () {
		RerollVelocity ();
		birthTime = Time.time;
		verticalOscillation = new Vector3 (0.0f, 0.0f, 0.0f);
	}

	// Update is called once per frame
	void Update () {
		verticalOscillation.y = Mathf.Sin (Time.time);
		transform.position += speed * Time.deltaTime * velocity;
		transform.position += 0.1f * Time.deltaTime * verticalOscillation;
		if (Time.time - birthTime >= path.arrivalTimes [current] && current < path.arrivalTimes.Count) {
			RerollVelocity ();
			current++;
			Debug.Log ("Changing");
		}
	}

	public void Hit () {
		Debug.Log("Ouch!");
		GameController.numberOfDucks--;
		Destroy (gameObject, 0.1f);
	}

	void TurnBack() {
		if (velocity.x > 0) {
			transform.Rotate (new Vector3 (0.0f, 90.0f, 0.0f), Space.Self);
		} else {
			transform.Rotate (new Vector3 (0.0f, -90.0f, 0.0f), Space.Self);
		}
		turned = false;
	}

	void Turn() {
		if (velocity.x > 0) {
			transform.Rotate (new Vector3 (0.0f, -90.0f, 0.0f), Space.Self);
		} else {
			transform.Rotate (new Vector3 (0.0f, 90.0f, 0.0f), Space.Self);
		}
		turned = true;
	}

	void RerollVelocity () {
		if (turned) {
			TurnBack ();
		}

		velocity = new Vector3 (Random.Range(-0.1f, 0.1f), Random.Range (0f, 0.1f), 0.0f);
		velocity.Normalize ();

		if (!turned) {
			Turn ();
		}

		speed = Random.Range (0.2f, 0.4f);
	}
}
