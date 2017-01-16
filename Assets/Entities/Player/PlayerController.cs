using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public float speed;

	public GameObject projectile;
	public GameObject projectileSpawn;
	public float projectileSpeed;
	public float firingRate = 4.0f;

	private Rigidbody2D playerProjectileRB;
	private ScoreKeeper scoreKeeper;

	private float playerHealth;

	void Start (){

		scoreKeeper = GameObject.Find ("ScoreBox").GetComponent<ScoreKeeper> ();

	}
	
	// Update is called once per frame
	void Update () {

		// MOVEMENT

		if (Input.GetKey (KeyCode.A)) {

			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.D)) {

			transform.position += Vector3.right * speed * Time.deltaTime;

		}

		//// restrict player to the gamespace
		float padding = 0.75f;
		float xMin = Screen.screenxMin + padding;
		float xMax = Screen.screenxMax - padding;

		float newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

		if (Input.GetKeyDown (KeyCode.Space)) {

			InvokeRepeating ("ProjectileFire", 0.000001f, firingRate);

		}

		if (Input.GetKeyUp (KeyCode.Space)) {

			CancelInvoke ("ProjectileFire");

		}

	}


	void ProjectileFire (){

		Instantiate (projectile, projectileSpawn.transform.position, Quaternion.identity);

	}




	void OnTriggerEnter2D(Collider2D col){


		enemyProjectile enemyProjectile = col.gameObject.GetComponent<enemyProjectile> ();

		if (enemyProjectile) {

			float hpHit = enemyProjectile.getDamage ();
			scoreKeeper.HealthHit (hpHit);
			enemyProjectile.Hit ();

			float hp = scoreKeeper.getHP ();

			if (hp <= 0) {
				
				Die ();

			}

		}	

	}

	void Die (){

		Debug.Log ("dead");
		LevelManager man = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		man.LoadLevel ("End");
		Destroy (gameObject);

	}
		
}
