using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	public Button playButton;
	public Text trackingPhaseText;
	public GameObject shotgun;
	public GameObject aim;


	// Use this for initialization
	void Start () {
		RemovePlayButton ();
		HideGun ();
		HideAim ();
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

}
