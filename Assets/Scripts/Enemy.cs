using UnityEngine;
using System.Collections;

public class Enemy : Entity {
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

		if (col.gameObject.tag == "Barrel") {

		}

	}

	void checkAlive(){
		if (health < 0) {
			Destroy (gameObject);
			//healthText.text = "P2 Health: 0";
		} else {
			//healthText.text = "P2 Health: "+ health;
		}
	}


}


