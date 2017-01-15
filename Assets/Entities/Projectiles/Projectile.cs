using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float damage = 100f;
	public float projectileHealth = 50f;

	public float getDamage(){

		return damage;

	}

	public void Hit(){

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
