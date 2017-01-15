using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour {

	public float damage = 50f;
	public float projectileHealth = 50f;

	Rigidbody2D projectileRB;

	void Start (){

	}

	void Update (){

		//Destroy self if velocity reduces to 0
		if (this.GetComponent<Rigidbody2D>().velocity.y >= 0f) {Destroy (gameObject);}

	}

	public float getDamage(){

		return damage;

	}

	public void Hit(){

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
