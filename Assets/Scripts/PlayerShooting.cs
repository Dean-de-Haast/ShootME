using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {



	public Rigidbody2D bulletPrefab,bulletUpgradedPrefab;
	private float coolDown;
	private AudioSource audio; 

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerShooting ();
	}



	void playerShooting(){
		GameObject go;
		go = GameObject.Find ("Player1");

		// Update is called once per frame
		if(Time.time >= coolDown){
			if(Input.GetMouseButton(0)){
				audio.Play ();
				//Depending on which gun is held depends which bullet is fired.
				if (go.GetComponent<Player> ().gunUpgraded) {
					Debug.Log ("Upgraded SHot");
					Rigidbody2D bPrefab = Instantiate (bulletUpgradedPrefab, new Vector3 (transform.position.x, transform.position.y , transform.position.z), Quaternion.identity) as Rigidbody2D;
					bPrefab.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletUpgradedPrefab.GetComponent<BulletSpecs>().bulletSpeed);

					coolDown = Time.time + bulletUpgradedPrefab.GetComponent<BulletSpecs>().attackSpeed;
					Destroy (bPrefab.gameObject, bulletUpgradedPrefab.GetComponent<BulletSpecs>().timeAlive);
				} else {
					Debug.Log ("Normal SHot");
					Rigidbody2D bPrefab = Instantiate (bulletPrefab, new Vector3 (transform.position.x , transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody2D;
					bPrefab.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletPrefab.GetComponent<BulletSpecs>().bulletSpeed);

					coolDown = Time.time + bulletPrefab.GetComponent<BulletSpecs>().attackSpeed;
					Destroy (bPrefab.gameObject, bulletPrefab.GetComponent<BulletSpecs>().timeAlive);
				}
			}
			go.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
	}

}
