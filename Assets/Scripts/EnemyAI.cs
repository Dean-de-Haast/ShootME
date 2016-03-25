using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	Transform player1;

	public Transform sighStart;
	public Transform sightEnd;
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
		Chase();
	}

	//Check for line of sight.
	void Raycasting(){
		Debug.DrawLine (sighStart.position,sightEnd.position, Color.green);
		//Check if touching collider.
		spottedObject = Physics2D.Linecast (sighStart.position, sightEnd.position, 1<<LayerMask.NameToLayer("Objects"));
		if (!spottedObject) {
			spotted = Physics2D.Linecast (sighStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("Players"));
		}
	}

	void Behaviours(){
		if (spotted) {
			alert.SetActive (true);
			//Chase();
		} else{
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

		transform.rotation = Quaternion.Euler (0, 0, zAngle);
	}
}
