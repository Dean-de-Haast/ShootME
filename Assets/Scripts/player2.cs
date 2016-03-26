using UnityEngine;
using System.Collections;

public class player2 : Entity {
	public float walkingSpeed;
	// Use this for initialization
	void Start () {
		healthText.text = "P2 Health: "+ health;
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
		Debug.Log (col.gameObject.tag);
		//Hit by a bullet
		if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "EnemyBullet" ) {
			Destroy (col.gameObject);
			health -= 34;
			Debug.Log (health);
			checkAlive ();
		}

		//Picks up health
		if (col.gameObject.tag == "HealthPack") {

			for (int i = 0; i < 20; i++) {
				if (health < 100) {
					health += 1;
				}
			}
			healthText.text = "P2 Health: "+ health;
		}

		if (col.gameObject.tag == "ExplosiveBarrel") {
			Rigidbody2D barrel = col.gameObject.GetComponent<Rigidbody2D>();
			barrel.isKinematic = false;
		}

	}




	void checkAlive(){
		if (health < 0) {
			Destroy (gameObject);
			healthText.text = "P2 Health: 0";
			manageLives();
		} else {
			healthText.text = "P2 Health: "+ health;
		}
	}
	void manageLives(){
		noLives--;
		if (noLives < 1) {
			Debug.Log ("GAME OVER");
		} else {
		}	
	}

}
