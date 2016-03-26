using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		Debug.Log ("WTF");
		if (col.gameObject.tag == "Bullet") {
			Destroy (col.gameObject);
			Debug.Log ("blow up");
		}

		if (col.gameObject.tag == "Player2") {

		}
	}
	
} 

