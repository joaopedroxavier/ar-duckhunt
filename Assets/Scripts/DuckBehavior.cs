using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBehavior : MonoBehaviour {

	// Use this for initialization

	private Vector3 velocity;
	private float speed = 0.1f;

	void Start () {
		RerollVelocity ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += velocity * speed * Time.deltaTime;
	}

	public void Hit () {
		Debug.Log("Ouch!");
		GameController.numberOfDucks--;
		Destroy (gameObject, 0.1f);
	}

	void RerollVelocity () {
		velocity = new Vector3 (0f, Random.Range (0f, 1f), 0f);
		velocity.Normalize ();
	}
}
