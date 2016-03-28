using UnityEngine;
using System.Collections;

public class player2 : Entity {
	public float walkingSpeed;
	public int keyCount = 0;
	public float damage;

	private AudioSource audio; 
	// Use this for initialization
	void Start () {
		healthText.text = "P2 Health: "+ health;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMovement ();
		audio = GetComponent<AudioSource> ();
	}
	//Controls player movement according to the user input.
	void PlayerMovement(){
		//Player walking movement - WASD..
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
			health -= 34;
			Destroy (col.gameObject);
			Debug.Log (health);
			audio.Play(); 
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
		//Open door if player collides with it.
		if (col.gameObject.tag == "Door"||col.gameObject.tag == "Door2") {
			openDoor (col);
		}
		//Player pics up key add a key to each players key counts.
		if (col.gameObject.tag == "Key") {
			keyCount++;
			Debug.Log (keyCount);
			GameObject.Find ("Player1").GetComponent<Player>().keyCount++;
		}

		if (col.gameObject.tag == "ExitDoor") {
			ExitLevel ();
		}
		if (col.gameObject.tag == "WinDoor") {
			Win ();
		}

	}
	//Checks to see if the player still has health
	public void checkAlive(){
		if (health < 0) {
			Destroy (gameObject);
			healthText.text = "P2 Health: 0";
			Application.LoadLevel ("Dead");
		} else {
			healthText.text = "P2 Health: "+ health;
		}
	}
	//Checks to see if player has enough keys to open the desired door.
	public void openDoor(Collision2D col){
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

	void ExitLevel(){
		Debug.Log ("Next Level");
		Application.LoadLevel ("Level2");
	}

	void Win(){
		Application.LoadLevel ("Win");
	}

}
