using UnityEngine;
using System.Collections;

public class CarAI : MonoBehaviour {
	public float speed;
	public float rotSpeed;
	public float damage;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.tag == "Wall") {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			transform.Rotate (0, 0, 180);
			GetComponent<Rigidbody2D> ().AddForce (transform.right * speed);
		}


		if (col.gameObject.tag == "Player1") {
			col.gameObject.GetComponent<Player>().health -= damage;
			col.gameObject.GetComponent<Player> ().checkAlive ();
		}

		if (col.gameObject.tag == "Player2") {
			col.gameObject.GetComponent<player2>().health -= damage;
			col.gameObject.GetComponent<player2> ().checkAlive ();
		}
	}


}
