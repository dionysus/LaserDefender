using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject projectileSpawn;
	public GameObject projectilePrefab;
	public float health = 150f;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue = 150;

	public AudioClip soundDestroy;
	//public AudioClip soundHit;

	//private Rigidbody2D enemyProjectileRB;
	private ScoreKeeper scoreKeeper;

	void Start (){

		scoreKeeper = GameObject.Find ("ScoreBox").GetComponent<ScoreKeeper> ();

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
				
				AudioSource.PlayClipAtPoint (soundDestroy, transform.position, 1.0f);
				Destroy (gameObject);
				scoreKeeper.Score (scoreValue);
			
			} else {
			
				//AudioSource.PlayClipAtPoint(soundHit, transform.position, 2.0f);

			}
		
			playerProjectile.Hit ();

		}
	}


	//Make 'em Shoot!
	void ProjectileFire (){

		Vector3 projectilePos = new Vector3 (projectileSpawn.transform.position.x, projectileSpawn.transform.position.y, 1.0f);

		//GameObject enemyProjectile = Instantiate (projectilePrefab, projectilePos, Quaternion.identity);
		Instantiate (projectilePrefab, projectilePos, Quaternion.identity);
	}

}