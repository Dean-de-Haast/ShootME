using UnityEngine;
using System.Collections;

public class Player : Entity {
	public float walkingSpeed;

	// Use this for initialization
	void Start () {
	
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

}
