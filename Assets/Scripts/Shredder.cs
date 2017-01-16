using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col){

		enemyProjectile enemyProjectile = col.gameObject.GetComponent<enemyProjectile> ();
		Projectile Projectile = col.gameObject.GetComponent<Projectile> ();

		if (enemyProjectile || Projectile) {

		//if (col.gameObject.tag == "playerProjectile") {
			Destroy (col.gameObject);

		}
	}

}
