using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour {

	public float damage = 50f;
	public float projectileHealth = 50f;
	public float projectileSpeed = 6f;
	public AudioClip soundShoot;
	public AudioClip soundHit;

	private Rigidbody2D projectileRB;

	void Start (){
		AudioSource.PlayClipAtPoint(soundShoot, transform.position);

		projectileRB = GetComponent<Rigidbody2D>();
		projectileRB.velocity = new Vector3 (0f, -projectileSpeed, 0f);

	}

	void Update (){

		//Destroy self if velocity reduces to 0
		if (GetComponent<Rigidbody2D>().velocity.y > projectileSpeed) {Destroy (gameObject);}

	}

	public float getDamage(){

		return damage;

	}

	public void Hit(){

		AudioSource.PlayClipAtPoint(soundHit, transform.position, 2.0f);
		Destroy (gameObject);

	}

	void OnCollisionEnter2D(Collision2D col){

		Projectile Projectile = col.gameObject.GetComponent<Projectile> ();

		if (Projectile) {

			Debug.Log ("collide!");

			projectileHealth -= Projectile.getDamage ();

			if (projectileHealth<= 0) {
				Destroy (gameObject);
			}

			//enemyProjectile.Hit ();

		}
	}

}
