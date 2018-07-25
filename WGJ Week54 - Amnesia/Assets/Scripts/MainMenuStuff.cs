using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuStuff : MonoBehaviour {

	public GameObject startButton, controlsBackButton;

	public GameObject mainMenu, controlsMenu;


	EventSystem eS;
	GameManager gM;

	// Use this for initialization
	void Start () {
		gM = FindObjectOfType<GameManager>();
		eS = FindObjectOfType<EventSystem>();
		eS.SetSelectedGameObject(startButton);


		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
	public void StartGame(){
		SceneManager.LoadScene(1);      
	}

	public void QuitGame(){
		Application.Quit();

	}

	public void ShowControlsPage(){
		eS.SetSelectedGameObject(null);
		mainMenu.SetActive(false);
		controlsMenu.SetActive(true);
		eS.SetSelectedGameObject(controlsBackButton);

	}

	public void BackToStartMenu(){
		eS.SetSelectedGameObject(null);
		controlsMenu.SetActive(false);
		mainMenu.SetActive(true);
		eS.SetSelectedGameObject(startButton);

        
	}


	public void ReplayGame(){
		gM.ResetGame();
		SceneManager.LoadScene(0);


	}
}
