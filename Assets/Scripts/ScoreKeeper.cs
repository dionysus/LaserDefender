using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	private static int score = 0;
	private static float hp;

	public float hpStart = 500f;
	public Text scoreText;
	public Text hpText;

	void Start() {

		hp = hpStart;
		hpText.text = hp.ToString ();
			
		score = 0;
		scoreText.text = score.ToString ();

	}

	public void Score (int points) {

		score += points;
		scoreText.text = score.ToString ();

	}

	public void HealthHit (float hpHit) {

		hp -= hpHit;
		hpText.text = hp.ToString ();;

	}

	void Reset () {

		score = 0;
		scoreText.text = score.ToString ();

	}


}
