using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckIconController : MonoBehaviour {

	public Sprite normal;
	public Sprite highlighted;
	public int presses = 0;

	// Use this for initialization
	void Start () {
		show ();
		turnOn ();
	}

	public void turnOff() {
		Image image = GetComponent<Image> ();
		image.sprite = normal;
	}

	public void turnOn() {
		Image image = GetComponent<Image> ();
		image.sprite = highlighted;
	}

	public void hide() {
		Image image = GetComponent<Image> ();
		image.enabled = false;
	}

	public void show() {
		Image image = GetComponent<Image> ();
		image.enabled = true;
	}
}
