using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	Transform player1;
	public float WalkingSpeed = 0.5f;
	public float rotSpeed = 90f;

	public Transform sightStart;
	public Transform sightEnd;
	public Transform sightEndFarLeft,sightEndFarLeft2,sightEndFarMiddle,sightEndFarRight,sightEndFarRight2;

	public bool spottedFar = false;
	public bool spotted = false;
	public bool spottedObject = false;

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
		spottedFar = false;
		Debug.DrawLine (sightStart.position,sightEnd.position, Color.green);
		Debug.DrawLine (sightStart.position,sightEndFarLeft.position, Color.red);
		Debug.DrawLine (sightStart.position,sightEndFarLeft2.position, Color.cyan);
		Debug.DrawLine (sightStart.position,sightEndFarMiddle.position, Color.blue);
		Debug.DrawLine (sightStart.position,sightEndFarRight.position, Color.magenta);
		Debug.DrawLine (sightStart.position,sightEndFarRight2.position, Color.yellow);

		//Check if touching collider.

		if (!spottedFar) {
			spottedFar = Physics2D.Linecast (sightStart.position, sightEndFarLeft.position, 1 << LayerMask.NameToLayer ("Players"));
		} 
		if (!spottedFar) {
			spottedFar = Physics2D.Linecast (sightStart.position, sightEndFarLeft2.position, 1 << LayerMask.NameToLayer ("Players"));
		}
		if (!spottedFar) {
			spottedFar = Physics2D.Linecast (sightStart.position, sightEndFarMiddle.position, 1 << LayerMask.NameToLayer ("Players"));
		} 
		if (!spottedFar) {
			spottedFar = Physics2D.Linecast (sightStart.position, sightEndFarRight.position, 1 << LayerMask.NameToLayer ("Players"));
		} 
		if (!spottedFar) {
			spottedFar = Physics2D.Linecast (sightStart.position, sightEndFarRight2.position, 1 << LayerMask.NameToLayer ("Players"));
		}


		spottedObject = Physics2D.Linecast (sightStart.position, sightEnd.position, 1<<LayerMask.NameToLayer("Objects"));

		if (!spottedObject) {
			spotted = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("Players"));
		}
	}

	void Behaviours(){
		if (spotted) {
			alert.SetActive (true);

		} else if (spottedFar) {
			alert.SetActive (true);
			Chase();
		}else{
			alert.SetActive (false);

		}	
	}

	void Chase(){
		GameObject go;
		if (player1 == null) {
			go = GameObject.Find ("Assassin");

			if(go !=null){
				player1 = go.transform;
			}
		}

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

	void MoveForward(){
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, WalkingSpeed * Time.deltaTime, 0);
		pos += transform.rotation * velocity;
		transform.position = pos;
	}
}
