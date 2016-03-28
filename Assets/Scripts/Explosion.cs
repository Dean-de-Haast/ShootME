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
	//Allow barrel movement only when player 2 moves it 
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Bullet") {
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "Player2") {	
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	}
	//Stop allowing movement.
	void OnCollisionExit2D () {
		gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
	}
} 

