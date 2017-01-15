using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

	public float width = 1f;
	public float height = 2f;


	void OnDrawGizmos() {

		//float width = this.GetComponent<SpriteRenderer> ().bounds.size.x;
		//float height = this.GetComponent<SpriteRenderer> ().bounds.size.y;

		//Gizmos.DrawWireSphere(transform.position, 0.5f);

		Gizmos.DrawWireCube(transform.position, new Vector3 (width, height));



	}

}
