using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	float xMin;
	float xMax;

	float padding = 0.75f;

	// Use this for initialization
	void Start () {

		//playerRB = GetComponent<Rigidbody2D>();

		float distance = transform.position.x - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;

	}
	
	// Update is called once per frame
	void Update () {

		//Vector2 playerPos = new Vector2 (this.transform.position.x, this.transform.position.y);
		//playerPos.x = Mathf.Clamp (playerRB.position.x, 1.0f, 8.0f);
		//this.transform.position = playerPos;


		if (Input.GetKey (KeyCode.A)) {

			//playerRB.position += new Vector2 (-speed * Time.deltaTime, 0);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.D)) {

			transform.position += Vector3.right * speed * Time.deltaTime;
			//playerRB.position += new Vector2 (speed * Time.deltaTime, 0);
		}

		//restrict player to the gamespace
		float newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

	}

}
