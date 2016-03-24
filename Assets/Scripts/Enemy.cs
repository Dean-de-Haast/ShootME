using UnityEngine;
using System.Collections;

public class Enemy : Entity {
	public Transform target;
	private Vector3 Player;
	private Vector2 PlayerDirection;
	private float xDif;
	private float yDif;
	public float speed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Player = GameObject.Find ("Assassin").transform.position;
		xDif = Player.x - transform.position.x;
		yDif = Player.y - transform.position.y;

		//Debug.Log (xDif + "     " + yDif);
		PlayerDirection = new Vector2 (xDif, yDif);

		GetComponent<Rigidbody2D>().AddForce (PlayerDirection.normalized * speed);


		/*if( TargetInRange() == true ){
			FireAtTarget();
		}
		//else if( bulletComingTowardsMe == true )
		//{
		//	MoveAwayFromBullet();
		//}
		else{
			WanderAroundAimlessly();
		}
	}

	bool TargetInRange(){
		//Debug.Log (gameObject.position.y);
		//Debug.Log (this.position.x);
		//Debug.Log ("TARGET");
		//Debug.Log (target.position.y);
		return false;
	}

	void FireAtTarget(){
	}

	void WanderAroundAimlessly(){
	}*/
	
	
	
	
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
			//healthText.text = "P2 Health: "+ health;
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


