using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class walkingBy : MonoBehaviour {

	Rigidbody2D rb;
	SpriteRenderer sr;
	Vector2 velocity;
	float chance;
	float riggedChance;
	Text myText;
	string tempString;
	bool once;
	Color myColor;
	Color[] colors;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		myText = GameObject.Find("Text").GetComponent<Text>();
		chance = Random.Range (0, 1f);
		tempString = myText.text;
		once = false;
		//colors = new Color[]{Color.yellow};
		//myColor = colors [0];
		//sr.color = myColor;

		PlayerPrefs.SetString ("Former", "");
		//Debug.Log (PlayerPrefs.GetString ("Former"));

		if (gameObject.tag == "LeftFriend") {
			velocity = new Vector2 (-5f, 0f);
		} else {
			velocity = new Vector2 (5f, 0f);
		}

		switch (PlayerPrefs.GetInt ("Wall")) {
		case 0:
			riggedChance = 0.9f;
			break;
		case 1:
			riggedChance = 0.8f;
			break;
		case 2:
			riggedChance = 0.7f;
			break;
		case 3:
			riggedChance = 0.6f;
			break;
		case 4:
			riggedChance = 0.6f;
			break;
		case 5:
			riggedChance = 0.5f;
			break;
		case 6:
			riggedChance = 0.4f;
			break;
		case 7:
			riggedChance = 0.4f;
			break;
		case 8:
			riggedChance = 0.3f;
			break;
		case 9:
			riggedChance = 0.3f;
			break;
		case 10:
			riggedChance = 0.2f;
			break;
		case 11:
			riggedChance = 0.1f;
			break;
		default:
			riggedChance = -1f;
			Debug.Log ("Default");
			break;
		}

		//Debug.Log (chance);
	}
	
	// Update is called once per frame
	void Update () {
		rb.MovePosition(rb.position + velocity * Time.deltaTime);
		if (gameObject.tag == "LeftFriend") {
			if (transform.position.x < -10f) {
				Destroy (gameObject);
			}
		} else {
			if (transform.position.x > 10f) {
				Destroy (gameObject);
			}
		}

		if (chance < riggedChance) {
			if (gameObject.tag == "LeftFriend") {
				if (transform.position.x < 2 && transform.position.x > 1) {
					stop ();
					if (!once) {
						talk ();
						once = true;
					}
					Invoke ("keepWalking", 3f);
				}
			} else {
				if (transform.position.x < -1 && transform.position.x > -2) {
					stop ();
					if (!once) {
						talk ();
						once = true;
					}
					Invoke ("keepWalking", 3f);
				}
			}
		}

	}

	void stop() {
		velocity = new Vector2 (0f, 0f);
	}

	void keepWalking() {
		if (gameObject.tag == "LeftFriend") {
			velocity = new Vector2 (-5f, 0f);
		} else {
			velocity = new Vector2 (5f, 0f);
		}
	}

	void talk() {
		//Debug.Log (PlayerPrefs.GetString ("Former"));
		tempString = myText.text;
		PlayerPrefs.SetString ("Former", tempString + "asdfghjkl");
		// \"
		myText.text = PlayerPrefs.GetString ("Former");
		//myText.color = myColor;
	}
}
