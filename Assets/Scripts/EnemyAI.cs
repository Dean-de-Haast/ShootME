using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform sighStart;
	public Transform sightEnd;
	public bool spotted = false;
	public bool spottedObject = false;
	// Use this for initialization
	void Start () {
		Debug.Log ("started");
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
	}
	
	// Update is called once per frame
	void Update () {
		Raycasting ();
	}
}
