using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Bullet") {
			Destroy (col.gameObject);
			Debug.Log ("blow up");
			Explode ();
		}

		if (col.gameObject.tag == "Player2") {	
			Debug.Log ("MOVE");
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	}

	void OnCollisionExit2D () {
		gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
	}

	void Explode() {
		Debug.Log ("BLOW 2");
	}
	
} 

