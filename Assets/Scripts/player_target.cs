using UnityEngine;
using System.Collections;

public class player_target : Entity {
	public float walkingSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMovement ();
	}

	void PlayerMovement(){
		if (Input.GetKey(KeyCode.D))
		{
			transform.position += new Vector3(walkingSpeed * Time.deltaTime, 0.0f, 0.0f);
			transform.eulerAngles = new Vector3 (0, 0, 0);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.position -= new Vector3(walkingSpeed * Time.deltaTime, 0.0f, 0.0f);
			transform.eulerAngles = new Vector3 (0, 0, 180);
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.position += new Vector3(0.0f, walkingSpeed * Time.deltaTime, 0.0f);
			transform.eulerAngles = new Vector3 (0, 0, 90);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.position -= new Vector3(0.0f, walkingSpeed * Time.deltaTime, 0.0f);
			transform.eulerAngles = new Vector3 (0, 0, 270);
		}
	}


	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Bullet") {
			Destroy (col.gameObject);
			health -= 34;
			Debug.Log (health);
			checkAlive ();
		}
	}

	void checkAlive(){
		if (health < 0) {
			Destroy (gameObject);
		}
	}
}
