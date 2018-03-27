﻿using System.Collections;
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
		Destroy (gameObject, 3f);
	}

	void RerollVelocity () {
		velocity = new Vector3 (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 0.1f));
		velocity.Normalize ();
	}
}