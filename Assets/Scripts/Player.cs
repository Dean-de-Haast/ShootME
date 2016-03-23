using UnityEngine;
using System.Collections;

public class Player : Entity {
	public float walkingSpeed;

	// Use this for initialization
	void Start () {
		healthText.text = "P2 Health: "+ health;
	}
	
	// Update is called once per frame
	void Update () {
		playerMovement ();
	}

	void playerMovement(){
		//Player walking movement.
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3 (walkingSpeed * Time.deltaTime, 0.0f, 0.0f);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position -= new Vector3 (walkingSpeed * Time.deltaTime, 0.0f, 0.0f);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += new Vector3 (0.0f, walkingSpeed * Time.deltaTime, 0.0f);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position -= new Vector3 (0.0f, walkingSpeed * Time.deltaTime, 0.0f);
		}


		//Rotation to the direction of the mouse pointer.
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rotation = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);
		transform.rotation = rotation;

		//Fixes twitchiness of turns.
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		GetComponent<Rigidbody2D> ().angularVelocity = 0;
	}

	void OnCollisionEnter2D(Collision2D col) {

		//Picks up health
		if (col.gameObject.tag == "HealthPack") {

			for (int i = 0; i < 20; i++) {
				if (health < 100) {
					health += 1;
				}
			}
			healthText.text = "P1 Health: "+ health;
		}

	}
	void checkAlive(){
		if (health < 0) {
			Destroy (gameObject);
			healthText.text = "P1 Health: 0";
		} else {
			healthText.text = "P1 Health: "+ health;
		}
	}

}
