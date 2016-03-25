using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {



	public Rigidbody2D bulletPrefab;
	public float attackSpeed = 0.5f;
	public float coolDown;
	public float bulletSpeed = 500;
	public float yValue = 1f; // Used to make it look like it's shot from the gun itself (offset)
	public float xValue = 0.2f; // Same as above
	public float timeAlive = 1f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		playerShooting ();
	}



	void playerShooting(){
		// Update is called once per frame
		if(Time.time >= coolDown){
				Rigidbody2D bPrefab = Instantiate(bulletPrefab, new Vector3(transform.position.x + xValue, transform.position.y + yValue, transform.position.z), Quaternion.identity) as Rigidbody2D;

				bPrefab.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);

				coolDown = Time.time + attackSpeed;
				Destroy (bPrefab.gameObject, 1);
		}
	}


}
