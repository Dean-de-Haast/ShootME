using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneHolder : MonoBehaviour {
	public string currentScene,newScene;
	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene ().name;
		newScene = currentScene;
	}
	
	// Update is called once per frame
	void Update () {
		newScene = SceneManager.GetActiveScene ().name;
		if (newScene != currentScene && newScene == "Dead") {
			currentScene = newScene;
		}
		Debug.Log ("running   " + currentScene );
	}
	void Awake(){
		
		DontDestroyOnLoad (this);
	}
}
