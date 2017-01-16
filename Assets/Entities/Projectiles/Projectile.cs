using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float damage = 100f;
	public float projectileHealth = 50f;
	public float projectileSpeed = 6f;
	public AudioClip soundShoot;
	public AudioClip soundHit;

	private Rigidbody2D projectileRB;

	// START HERE

	void Start (){

		AudioSource.PlayClipAtPoint(soundShoot, transform.position);

		projectileRB = GetComponent<Rigidbody2D>();
		projectileRB.velocity = new Vector3 (0f, projectileSpeed, 0f);

	}

	public float getDamage(){

		return damage;

	}

	public void Hit(){

		AudioSource.PlayClipAtPoint(soundHit, transform.position, 2.0f);
		Destroy (gameObject);

	}

	void OnCollisionEnter2D(Collision2D col){


		enemyProjectile enemyProjectile = col.gameObject.GetComponent<enemyProjectile> ();


		if (enemyProjectile) {

			Debug.Log ("collide!");

			projectileHealth -= enemyProjectile.getDamage ();

			if (projectileHealth<= 0) {
				Destroy (gameObject);
			}

			//enemyProjectile.Hit ();

		}
	}

}
