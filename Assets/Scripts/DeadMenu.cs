using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour {
	public string mainMenu;
	public string levelSelect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SelectLevel(){
		SceneManager.LoadScene(levelSelect);
	}

	public void MainMenu(){
		SceneManager.LoadScene(mainMenu);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
