using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {
	public string level1, level2;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void levelOne(){
		SceneManager.LoadScene(level1);
	}

	public void levelTwo(){
		SceneManager.LoadScene(level2);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
