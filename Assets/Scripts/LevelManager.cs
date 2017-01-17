using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;
	public bool autoLoad = false;

	void Start(){

		if (autoLoad) {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}


	public void LoadLevel(string name){
		
		SceneManager.LoadScene(name);
	}

	public void LoadNextLevel(){

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);

	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
