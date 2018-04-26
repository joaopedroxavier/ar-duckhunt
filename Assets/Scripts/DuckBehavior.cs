using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBehavior : MonoBehaviour {

	// Use this for initialization

	private Vector3 velocity;
	private float linearSpeed;
	private float flyingSpeed;
	private float radius;
	int current = 0;
	float birthTime;
	bool turned = false;
	Vector3 verticalOscillation;

	void Start () {
		//RerollVelocity ();
		birthTime = Time.time;
		linearSpeed = Random.Range(0.1f, 0.3f);
		flyingSpeed = Random.Range(0.1f, 0.2f);
		radius = Random.Range(0.05f, 0.15f);
	}

	// Update is called once per frame
	void Update () {
		HelicoidalMotion ();
	}

	void HelicoidalMotion() {
		transform.position += flyingSpeed * Time.deltaTime * transform.up;
		transform.position -= linearSpeed * Time.deltaTime * transform.forward;
		float angularSpeed = linearSpeed / radius;
		transform.Rotate(Vector3.up * angularSpeed * Time.deltaTime * 360 / (2*Mathf.PI));
	}

	public void Hit () {
		Debug.Log("Ouch!");
		GameController.numberOfDucks--;
		Destroy (gameObject, 0.1f);
	}

	void RerollVelocity () {
		velocity = new Vector3 (Random.Range(-0.1f, 0.1f), Random.Range (0f, 0.1f), 0.0f);
		velocity.Normalize ();

		//speed = Random.Range (0.2f, 0.4f);
	}
}
