﻿using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {



	public Rigidbody2D bulletPrefab;
	public float attackSpeed = 0.5f;
	public float coolDown;
	public float bulletSpeed = 500;
	public float timeAlive = 1f;
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
		// Update is called once per frame
		if(Time.time >= coolDown){
			audio.Play ();
			Rigidbody2D bPrefab = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody2D;
			bPrefab.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);

			coolDown = Time.time + attackSpeed;
			Destroy (bPrefab.gameObject, 1);
		}
	}


}
