using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public float playerHealth = 500f;
	public float speed;

	public GameObject projectile;
	public GameObject projectileSpawn;
	public float projectileSpeed;
	public float firingRate = 4.0f;

	private Rigidbody2D playerProjectileRB;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// MOVEMENT

		if (Input.GetKey (KeyCode.A)) {

			//playerRB.position += new Vector2 (-speed * Time.deltaTime, 0);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.D)) {

			transform.position += Vector3.right * speed * Time.deltaTime;
			//playerRB.position += new Vector2 (speed * Time.deltaTime, 0);
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

		GameObject playerProjectile = Instantiate (projectile, projectileSpawn.transform.position, Quaternion.identity);
		playerProjectileRB = playerProjectile.GetComponent<Rigidbody2D>();
		playerProjectileRB.velocity = new Vector3 (0f, projectileSpeed, 0f);

	}

	void OnTriggerEnter2D(Collider2D col){



		enemyProjectile enemyProjectile = col.gameObject.GetComponent<enemyProjectile> ();

		if (enemyProjectile) {

			//Debug.Log ("player hit!!");

			playerHealth -= enemyProjectile.getDamage ();
			Debug.Log (playerHealth);

			if (playerHealth <= 0) {
				Debug.Log ("dead");
			}

			enemyProjectile.Hit ();

		}
	}

}
