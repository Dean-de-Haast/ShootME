using UnityEngine;
using System.Collections;

public class Enemy : Entity {

	public GameObject alert;
	public GameObject bloodPrefab;
	public Sprite sprite1,sprite2; // Drag your first sprite here
	public float rotSpeed = 180f;

	//public float dieDelay = 0.4f;

	private SpriteRenderer spriteRenderer; 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col) {
		

		//Hit by a bullet
		if (col.gameObject.tag == "Bullet") {
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
		}

		if (col.gameObject.tag == "Barrel"||col.gameObject.tag == "Wall"||col.gameObject.tag == "Door") {
			changeDirection ();
		}

	}

	void checkAlive(){
		if (health < 0) {
			
			//Destroy (gameObject);
			//healthText.text = "P2 Health: 0";
			Death();
		} else {
			//healthText.text = "P2 Health: "+ health;
		}
	}

	void Death(){
		
		alert.SetActive (false);
		//transform.position = transform.position;
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject

		//waiter ();
		Instantiate(bloodPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		spriteRenderer.sprite = sprite1;
		Destroy (gameObject,0.4f);
	}

	void changeDirection(){
		//Quaternion desiredRot = Quaternion.Euler (0, 0, 45);

		//Slowing down the speed of rotation.
		//transform.rotation = Quaternion.RotateTowards(transform.rotation,desiredRot,rotSpeed*Time.deltaTime);
		transform.Rotate(0,0,45);
	}



}


