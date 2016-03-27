using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public string startLevel;
	public string levelSelect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewGame(){
		Application.LoadLevel (startLevel);
	}

	public void LevelSelect(){
		Application.LoadLevel (levelSelect);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
