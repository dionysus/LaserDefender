using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speedH = 5f;
	public float speedV = 2f;


	private bool movingRight = true;

	// Use this for initialization
	void Start () {

		foreach (Transform child in transform) { //for every child in the enemy spawner
			
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child; //set to this

		}

	}

	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3 (width, height));
	}

	// Update is called once per frame
	void Update () {


	// Constrain to screen bounds
		float padding = width / 2;
		float xMin = Screen.screenxMin + padding;
		float xMax = Screen.screenxMax - padding;

		transform.position += Vector3.down * speedV * Time.deltaTime; 

		if (movingRight){
			transform.position += Vector3.right * speedH * Time.deltaTime; 
		}

		if (!movingRight){
			transform.position += Vector3.left * speedH * Time.deltaTime; 
		}
			
		if (transform.position.x >= xMax) { movingRight = false; }
		if (transform.position.x <= xMin) { movingRight = true; }

	// If all dead then...

		if (AllMembersDead ()) {
			Debug.Log ("Empty Formation");
		}


	}

	bool AllMembersDead(){

		//transform.childCount;
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount>0) {return false;}

		}

		return true;
	}

		
}
