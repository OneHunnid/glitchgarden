using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;

	private Button[] buttonArray;
	private Text costText;

	public static GameObject selectedDefender;

	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button> ();

		costText = GetComponentInChildren<Text> ();

		if (!costText) {
			Debug.Log (name + " has no cost text");
		}

		costText.text = defenderPrefab.GetComponent<Defender> ().starCost.ToString ();
	}
	
	void Update () {
		
	}

	void OnMouseDown() {

		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}

		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
