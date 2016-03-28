using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	Transform player1;
	public float WalkingSpeed = 0.5f;
	public float rotSpeed = 90f;

	public GameObject FirePoint;

	//All of the transforms for use within the linecast.
	public Transform sightStart;
	public Transform sightEnd, sightEndObject;
	public Transform sightEndFarLeft,sightEndFarLeft2,sightEndFarMiddle,sightEndFarRight,sightEndFarRight2,sightEndFarFarLeft,sightEndFarFarRight;

	public bool spottedFarP1 = false;
	public bool spottedFarP2 = false;
	public bool spottedP1 = false;
	public bool spottedP2 = false;
	public bool spottedObject = false;

	public bool gotShot = false;
	public bool gotHit = false;

	public int count = 0;
	public int count2 = 0;

	public GameObject alert;
	// Use this for initialization
	void Start () {
		Debug.Log ("started");
	}

	// Update is called once per frame
	void Update () {
		Raycasting ();
		Behaviours ();
		//MoveForward ();
	}

	//Check for line of sight.
	void Raycasting(){
		spottedFarP1 = false;
		spottedFarP2 = false;
		//For testing. draw the lines.
		Debug.DrawLine (sightStart.position,sightEnd.position, Color.green);
		Debug.DrawLine (sightStart.position,sightEndFarFarLeft.position, Color.red);
		Debug.DrawLine (sightStart.position,sightEndFarLeft.position, Color.red);
		Debug.DrawLine (sightStart.position,sightEndFarLeft2.position, Color.cyan);
		Debug.DrawLine (sightStart.position,sightEndFarMiddle.position, Color.blue);
		Debug.DrawLine (sightStart.position,sightEndFarRight.position, Color.magenta);
		Debug.DrawLine (sightStart.position,sightEndFarFarRight.position, Color.magenta);
		Debug.DrawLine (sightStart.position,sightEndFarRight2.position, Color.yellow);

		//Check if touching collider.

		//First checks whether the short linecast hits an object because then there is an object before the player.
		spottedObject = Physics2D.Linecast (sightStart.position, sightEndObject.position, 1<<LayerMask.NameToLayer("Objects"));

		//Player 1
		if (!spottedObject) {
			spottedP1 = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("Player1"));
			if (!spottedFarP1) {
				spottedFarP1 = Physics2D.Linecast (sightStart.position, sightEndFarFarLeft.position, 1 << LayerMask.NameToLayer ("Player1"));
			} 
			if (!spottedFarP1) {
				spottedFarP1 = Physics2D.Linecast (sightStart.position, sightEndFarLeft.position, 1 << LayerMask.NameToLayer ("Player1"));
			} 
			if (!spottedFarP1) {
				spottedFarP1 = Physics2D.Linecast (sightStart.position, sightEndFarLeft2.position, 1 << LayerMask.NameToLayer ("Player1"));
			}
			if (!spottedFarP1) {
				spottedFarP1 = Physics2D.Linecast (sightStart.position, sightEndFarMiddle.position, 1 << LayerMask.NameToLayer ("Player1"));
			} 
			if (!spottedFarP1) {
				spottedFarP1 = Physics2D.Linecast (sightStart.position, sightEndFarFarRight.position, 1 << LayerMask.NameToLayer ("Player1"));
			} 
			if (!spottedFarP1) {
				spottedFarP1 = Physics2D.Linecast (sightStart.position, sightEndFarRight.position, 1 << LayerMask.NameToLayer ("Player1"));
			} 
			if (!spottedFarP1) {
				spottedFarP1 = Physics2D.Linecast (sightStart.position, sightEndFarRight2.position, 1 << LayerMask.NameToLayer ("Player1"));
			}
		}

		//Player 2
		if (!spottedObject) {
			spottedP2 = Physics2D.Linecast (sightStart.position, sightEndObject.position, 1 << LayerMask.NameToLayer ("Player2"));
			if (!spottedFarP2) {
				spottedFarP2 = Physics2D.Linecast (sightStart.position, sightEndFarFarLeft.position, 1 << LayerMask.NameToLayer ("Player2"));
			} 
			if (!spottedFarP2) {
				spottedFarP2 = Physics2D.Linecast (sightStart.position, sightEndFarLeft.position, 1 << LayerMask.NameToLayer ("Player2"));
			} 
			if (!spottedFarP2) {
				spottedFarP2 = Physics2D.Linecast (sightStart.position, sightEndFarLeft2.position, 1 << LayerMask.NameToLayer ("Player2"));
			}
			if (!spottedFarP2) {
				spottedFarP2 = Physics2D.Linecast (sightStart.position, sightEndFarMiddle.position, 1 << LayerMask.NameToLayer ("Player2"));
			} 
			if (!spottedFarP2) {
				spottedFarP2 = Physics2D.Linecast (sightStart.position, sightEndFarFarRight.position, 1 << LayerMask.NameToLayer ("Player2"));
			} 
			if (!spottedFarP2) {
				spottedFarP2 = Physics2D.Linecast (sightStart.position, sightEndFarRight.position, 1 << LayerMask.NameToLayer ("Player2"));
			} 
			if (!spottedFarP2) {
				spottedFarP2 = Physics2D.Linecast (sightStart.position, sightEndFarRight2.position, 1 << LayerMask.NameToLayer ("Player2"));
			}
		}



	}

	//The different states that a player can be in.
	void Behaviours(){
		//If close enough start shooting.
		if (spottedP1 || spottedP2) {
			Debug.Log ("SHOOT");
			alert.SetActive (true);
			StartShooting ();
			//If the enemy is close enough and in line of sight to 'see' the Player chase him until in Range of shooting.
		} else if (spottedFarP1) {
			alert.SetActive (true);
			ChasePlayer1 ();
		} else if (spottedFarP2) {
			ChasePlayer2 ();
		} else if (gotShot) {
			count++;
			alert.SetActive (true);
			ChasePlayer1 ();
			//Gives enough time for the enemy to spin around and get in spotted.
			if (count > 100) {
				gotShot = false;
			}
		} else if (gotHit) {
			count++;
			alert.SetActive (true);
			ChasePlayer2 ();
			//Gives enough time for the enemy to spin around and get in spotted.
			if (count2 > 100) {
				gotHit = false;
			}
		}else{
			alert.SetActive (false);
			Patrol ();
		}

		//Stop Shooting if no longer in close range.
		if(!spottedP1 && !spottedP2){
			StopShooting ();
		}	
	}
		
	//Script to chase a player, if spotted reorintates to face the player. and moves towards the player.
	public void ChasePlayer1(){
		GameObject go;
		if (player1 == null) {
			go = GameObject.Find ("Player1");

			if(go !=null){
				player1 = go.transform;
			}
		}

		if (player1 == null)
			return; // Try again next frame if it doesn't exist.
		
		Debug.Log("2");
		Vector3 dir = player1.position - transform.position;
		dir.Normalize ();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) *Mathf.Rad2Deg - 90; //Gets the angle along x axis therefore turn 90

		Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);

		//Slowing down the speed of rotation.
		transform.rotation = Quaternion.RotateTowards(transform.rotation,desiredRot,rotSpeed*Time.deltaTime);
		MoveForward ();
	}

	//MOves the object forward.
	void MoveForward(){
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, WalkingSpeed * Time.deltaTime, 0);
		pos += transform.rotation * velocity;
		transform.position = pos;
	}

	//Script to chase a player, if spotted reorintates to face the player. and moves towards the player.
	public void ChasePlayer2(){
		GameObject go;
		//Checks whether the player is already held if not assigns it.
		if (player1 == null) {
			go = GameObject.Find ("Player2");

			if(go !=null){
				player1 = go.transform;
			}
		}
		//If it does not exist.
		if (player1 == null)
			return; // Try again next frame if it doesn't exist.
		Vector3 dir = player1.position - transform.position;
		dir.Normalize ();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) *Mathf.Rad2Deg - 90; //Gets the angle along x axis therefore turn 90

		Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);

		//Slowing down the speed of rotation.
		transform.rotation = Quaternion.RotateTowards(transform.rotation,desiredRot,rotSpeed*Time.deltaTime);
		MoveForward ();
	}

	//Walk randomly if not in alerted state.
	void Patrol(){
		Vector2 randomDirection = new Vector3(Random.Range(-30, 30), Random.Range(-30, 30));
		randomDirection.Normalize ();

		float zAngle = Mathf.Atan2 (randomDirection.y, randomDirection.x) *Mathf.Rad2Deg - 90; //Gets the angle along x axis therefore turn 90

		Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);

		//Slowing down the speed of rotation.
		transform.rotation = Quaternion.RotateTowards(transform.rotation,desiredRot,rotSpeed*Time.deltaTime);
		MoveForward ();
	}

	void StartShooting(){
		FirePoint.GetComponent<EnemyShooting>().enabled = true;
	}

	void StopShooting(){
		FirePoint.GetComponent<EnemyShooting>().enabled = false;
	}
}
