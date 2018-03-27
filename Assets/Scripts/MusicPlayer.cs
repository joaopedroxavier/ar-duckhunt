using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance;

	void Start() {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	public void Toggle() {
		AudioSource player = GetComponent<AudioSource> ();
		player.mute = !player.mute;
	}
}
