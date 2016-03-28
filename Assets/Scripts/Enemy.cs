using UnityEngine;
using System.Collections;

public class Enemy : Entity {

	public GameObject alert;
	public GameObject bloodPrefab;
	public Sprite sprite1,sprite2; // Drag your first sprite here
	public float rotSpeed = 180f;

	private AudioSource audioShot; 
	//public float dieDelay = 0.4f;

	private SpriteRenderer spriteRenderer; 


	// Use this for initialization
	void Start () {
		audioShot = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col) {
		

		//Hit by a bullet
		if (col.gameObject.tag == "Bullet") {
			Destroy (col.gameObject);
			health -= col.gameObject.GetComponent<BulletSpecs>().damage;
			audioShot.Play ();
			checkAlive ();
			gameObject.GetComponent<EnemyAI> ().gotShot = true;
			gameObject.GetComponent<EnemyAI> ().count = 0;
		}

		//Hit by PLayer2
		if (col.gameObject.tag == "Player2") {
			health -= col.gameObject.GetComponent<player2>().damage;
			checkAlive();
			gameObject.GetComponent<EnemyAI> ().gotHit = true;
			gameObject.GetComponent<EnemyAI> ().count2 = 0;

		}

		//Reverse Direction if a player hits an object
		if (col.gameObject.tag == "Barrel"||col.gameObject.tag == "Wall"||col.gameObject.tag == "Door"||col.gameObject.tag == "Door2"||col.gameObject.tag == "ExitDoor"||col.gameObject.tag == "ExplosiveBarrel") {
			changeDirection ();
		}

	}

	//Checks to see if player still has health.
	void checkAlive(){
		if (health <= 0) {
			Death();
		}
	}

	//When life<0 destroy object but first change sprite.
	void Death(){
		alert.SetActive (false);
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		Instantiate(bloodPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		spriteRenderer.sprite = sprite1;
		//wait 0.4seconds before destroying.
		Destroy (gameObject,0.4f);
	}

	void changeDirection(){
		transform.Rotate(0,0,45);
	}



}


