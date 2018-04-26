using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	int numLevelText;

	// Use this for initialization
	void Start () {
		numLevelText = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (numLevelText != GameController.levelCount) {
			UpdateText (GameController.levelCount.ToString());
			numLevelText = GameController.levelCount;
		}
	}

	void UpdateText(string newText) {
		GameObject textComponent = GameObject.Find ("ScoreText");
		textComponent.GetComponent<Text> ().text = newText;
	}
}
