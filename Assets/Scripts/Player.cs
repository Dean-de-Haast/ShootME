using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : Entity {
	public float walkingSpeed;
	public bool gunUpgraded =false;

	//public string currentScene;

	public int keyCount = 0;

	private AudioSource audio; 

	private SpriteRenderer spriteRenderer; 
	public Sprite newGun;
	// Use this for initialization
	void Start () {
		healthText.text = "P1 Health: "+ health;
		audio = GetComponent<AudioSource> ();


	}
	
	// Update is called once per frame
	void Update () {
		playerMovement ();
	}

	//Controls player movement according to the user input.
	void playerMovement(){
		//Player walking movement - Arrow keys..
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

		//Player Direction controlled by the mouse.

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
			healthText.text = "P1 Health: "+ health;
		}

		//Player pics up key add a key to each players key counts.
		if (col.gameObject.tag == "Key") {
			keyCount++;
			GameObject.Find ("Player2").GetComponent<player2>().keyCount++;
		}
			
		//Open door if player collides with it.
		if (col.gameObject.tag == "Door"||col.gameObject.tag == "Door2") {
			openDoor (col);
		}
		//Allow for gunUpgrade.
		if (col.gameObject.tag == "GunUpgrade") {
			changeGun ();
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
			healthText.text = "P1 Health: 0";
			Application.LoadLevel ("Dead");
		} else {
			healthText.text = "P1 Health: "+ health;
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

	//Upgrade the gun to the new gun, change the sprite and change the bool to true
	void changeGun(){
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		spriteRenderer.sprite = newGun;
		gunUpgraded = true;

	}

	void ExitLevel(){
		Application.LoadLevel ("Level2");
	}
	void Win(){
		Application.LoadLevel ("Win");
	}


}
