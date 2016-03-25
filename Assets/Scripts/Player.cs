using UnityEngine;
using System.Collections;

public class Player : Entity {
	public float walkingSpeed;
	private int keyCount = 0;

	// Use this for initialization
	void Start () {
		healthText.text = "P1 Health: "+ health;
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
		//Debug.Log (transform.position - mousePos);
		transform.rotation = rotation;

		//Fixes twitchiness of turns.
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		GetComponent<Rigidbody2D> ().angularVelocity = 0;
	}

	void OnCollisionEnter2D(Collision2D col) {
		

		//Gets shot
		//Hit by a bullet
		if (col.gameObject.tag == "EnemyBullet") {
			Destroy (col.gameObject);
			health -= 34;
			checkAlive ();
		}

		//Picks up health
		if (col.gameObject.tag == "HealthPack") {

			for (int i = 0; i < 20; i++) {
				if (health < 100) {
					health += 1;
				}
			}
			healthText.text = "P1 Health: "+ health;
		}

		if (col.gameObject.tag == "Key") {
			keyCount++;
		}

		if (col.gameObject.tag == "Door"||col.gameObject.tag == "Door2") {
			//Debug.Log ("WTF" + keyCount);
			openDoor (col);
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

	void openDoor(Collision2D col){
		if (col.gameObject.tag == "Door") {
			if (keyCount > 0) { //Only requires one key to unlock.
				Destroy (col.gameObject);
			}
		} else if (col.gameObject.tag == "Door2") {
			if (keyCount > 1) {  //Door2 requires 2 keys to unlock
				Destroy (col.gameObject);
			}
		}
	}



}
