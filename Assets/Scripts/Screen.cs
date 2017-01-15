using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour {

	public static float screenxMin;
	public static float screenxMax;


	// Use this for initialization
	void Start () {
	
		float distance = transform.position.x - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		screenxMin = leftmost.x;
		screenxMax = rightmost.x;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
