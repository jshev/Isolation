using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndDrop : MonoBehaviour {

	public AudioClip drop;
	public AudioClip pickUp;

	AudioSource audioSource;
	Vector3 screenPoint;
	Vector3 offset;
	bool mortar;
	int tempNum;
	GameObject player;

	// Use this for initialization
	void Start () {
		mortar = false;
		tempNum = 0;
		PlayerPrefs.SetInt ("Wall", 0);
		player = GameObject.Find ("You");
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log ("Mortared bricks: " + PlayerPrefs.GetInt ("Wall"));
		tempNum = PlayerPrefs.GetInt ("Wall");
	}

	void OnMouseUp() {
		if (transform.position.x > -1.75 && transform.position.x < 1.75) {
			mortar = true;
			PlayerPrefs.SetInt ("Wall", tempNum + 1);
			if (PlayerPrefs.GetInt ("Wall") < 12) {
				player.transform.localScale -= new Vector3 (0.08f, 0.08f, 0);
			}
		}
	}

	void OnMouseDown(){
		if (!mortar) {
			audioSource.PlayOneShot(pickUp, 0.3f);
			screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}
	}

	void OnMouseDrag(){
		if (!mortar) {
			Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
			transform.position = cursorPosition;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
			audioSource.PlayOneShot (drop, 0.15f);
	}
}
