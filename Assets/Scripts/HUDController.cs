using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	public Button playButton;
	public Text trackingPhaseText;
	public GameObject shotgun;
	public GameObject aim;
	public GameObject duckBar;
	public Text roundText;

	// Use this for initialization
	void Start () {
		RemovePlayButton ();
		HideGun ();
		HideAim ();
		HideDuckBar ();
		HideRoundText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RemoveTrackingText() { trackingPhaseText.gameObject.SetActive (false); }

	public void EnablePlayButton() { playButton.gameObject.SetActive (true); }

	public void RemovePlayButton() { playButton.gameObject.SetActive (false); }

	public void ShowGun() { shotgun.gameObject.SetActive (true); }

	public void HideGun() { shotgun.gameObject.SetActive (false);  }

	public void ShowAim() {	aim.gameObject.SetActive (true); }

	public void HideAim() {	aim.gameObject.SetActive (false); }

	public void ShowDuckBar() { duckBar.gameObject.SetActive (true); }

	public void HideDuckBar() { duckBar.gameObject.SetActive (false); }

	public void HideRoundText() { roundText.gameObject.SetActive (false); }

	public void ShowRoundText() { roundText.gameObject.SetActive (true); }

	public void loadRound(int numberOfDucks) { duckBar.GetComponent<DuckBarController> ().loadRound (numberOfDucks); }

	public void PlayReadyAnimation() {
		Debug.Log ("Coe");
		StartCoroutine (ReadyAnimation ());
	}

	IEnumerator ReadyAnimation() {
		ShowRoundText ();
		roundText.GetComponent<Text> ().text = "Ready...";
		yield return new WaitForSeconds (1.0f);
		StartCoroutine (SetAnimation());
	}

	IEnumerator SetAnimation() {
		ShowRoundText ();
		roundText.GetComponent<Text> ().text = "Set...";
		yield return new WaitForSeconds (1.0f);
		StartCoroutine (GoAnimation());
	}

	IEnumerator GoAnimation() {
		ShowRoundText ();
		roundText.GetComponent<Text> ().text = "Go!";
		yield return new WaitForSeconds (1.0f);
		HideRoundText ();
	}

	public void Wait() {
		StartCoroutine ("WaitLoader");
	}

	IEnumerator WaitLoader() {
		yield return new WaitForSeconds (1);
	}
}
