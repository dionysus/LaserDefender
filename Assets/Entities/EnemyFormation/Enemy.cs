using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject projectileSpawn;
	public GameObject projectilePrefab;
	public float projectileSpeed = 2.0f;
	//public float firingRate = 1.0f;
	public float health = 150f;
	public float shotsPerSeconds = 0.5f;

	private Rigidbody2D enemyProjectileRB;

	void Start (){

		//InvokeRepeating ("ProjectileFire", 0.000001f, firingRate);

	}

	void Update (){

		float probability = shotsPerSeconds * Time.deltaTime;
		if (Random.value < probability) {
			ProjectileFire ();
		}

	}

	// When hit!!
	void OnTriggerEnter2D(Collider2D col){

		Projectile playerProjectile = col.gameObject.GetComponent<Projectile> ();

		if (playerProjectile) {

			health -= playerProjectile.getDamage ();

			if (health <= 0) {
				Destroy (gameObject);
			}
		
			playerProjectile.Hit ();

		}
	}


	//Make 'em Shoot!
	void ProjectileFire (){

		Vector3 projectilePos = new Vector3 (projectileSpawn.transform.position.x, projectileSpawn.transform.position.y, 1.0f);

		GameObject enemyProjectile = Instantiate (projectilePrefab, projectilePos, Quaternion.identity);

		enemyProjectileRB = enemyProjectile.GetComponent<Rigidbody2D>();
		enemyProjectileRB.velocity = new Vector3 (0f, -projectileSpeed, 0f);

	}

}