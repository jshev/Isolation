using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gone : MonoBehaviour {

	Text myText;

	// Use this for initialization
	void Start () {
		myText = GameObject.Find("Text").GetComponent<Text>();
		//GetComponent<SpriteRenderer> ().color = new Color (0.08f, 0.46f, 0.87f);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Mortared bricks: " + PlayerPrefs.GetInt ("Wall"));

		if (Input.GetKeyDown (KeyCode.A)) {
			transform.localScale -= new Vector3(0.1f, 0.1f, 0);
		}

		if (PlayerPrefs.GetInt ("Wall") == 12) {
			myText.text = ". . .";
			myText.alignment = TextAnchor.UpperCenter;
			myText.color = Color.white;
			Invoke ("loadMenu", 10f);
		}

		if (Input.GetKeyDown(KeyCode.R)) {
			loadMenu ();
		}
		
	}

	void loadMenu() {
		SceneManager.LoadScene("Menu");
	}
}
