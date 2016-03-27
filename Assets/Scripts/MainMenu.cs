using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public string mainMenu;
	public string startLevel;
	public string controlView;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewGame(){
		SceneManager.LoadScene(startLevel);
	}

	public void Control(){
		SceneManager.LoadScene(controlView);
	}

	public void QuitGame(){
		Application.Quit ();
	}
	public void Back(){
		SceneManager.LoadScene(mainMenu);
	}
}
