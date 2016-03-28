using UnityEngine;
using System.Collections;

public class CarAI : MonoBehaviour {
	public float speed;
	public float rotSpeed;
	public float damage;

	public GameObject explosion;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D col) {
		//Changes direction when reaches the wall.
		if (col.gameObject.tag == "Wall") {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			transform.Rotate (0, 0, 180);
			GetComponent<Rigidbody2D> ().AddForce (transform.right * speed);
		}

		//PLayer takes damage if hit
		if (col.gameObject.tag == "Player1") {
			col.gameObject.GetComponent<Player>().health -= damage;
			col.gameObject.GetComponent<Player> ().checkAlive ();
		}
		//PLayer takes damage if hit
		if (col.gameObject.tag == "Player2") {
			col.gameObject.GetComponent<player2>().health -= damage;
			col.gameObject.GetComponent<player2> ().checkAlive ();
		}

		//If it hits a barrel, create explosion.
		if (col.gameObject.tag == "ExplosiveBarrel") {
			Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
	}


}
