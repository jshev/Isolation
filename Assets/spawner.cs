using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
	public GameObject goingLeftPrefab;
	public GameObject goingRightPrefab;

	// Use this for initialization
	void Start () {
		if (gameObject.name == "LeftSpawner") {
			InvokeRepeating("launchRight", 0f, 5f);
		} else {
			InvokeRepeating("launchLeft", 3f, 8f);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void launchLeft() {
		// instantiate new cells from spawner
		GameObject passerby = Instantiate(goingLeftPrefab) as GameObject;
		passerby.transform.position = transform.position;
	}

	void launchRight() {
		// instantiate new cells from spawner
		GameObject passerby = Instantiate(goingRightPrefab) as GameObject;
		passerby.transform.position = transform.position;
	}
}
