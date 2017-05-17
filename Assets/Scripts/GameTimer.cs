using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;

	public float secondsLeft; // TODO Make private later
	private Slider slider;
	private bool isEndOfLevel = false;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private GameObject winLabel;

	void Start () {
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		FindYouWin ();
		winLabel.SetActive (false);
	}

	void FindYouWin() {
		winLabel = GameObject.Find ("You Win");

		if (!winLabel) {
			Debug.LogWarning ("Please create You Win object");
		}
	}
	
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
	
		if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
			audioSource.Play ();
			winLabel.SetActive (true);
			Invoke ("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;
		}
	}

	void LoadNextLevel() {
		levelManager.LoadNextLevel();
	}
}
