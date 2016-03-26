using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Picks up health
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag != "Bullet"&&col.gameObject.tag != "ExplosiveBarrel") {
			Destroy (gameObject);
		}
	}
}
