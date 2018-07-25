using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseScreen;
	public GameObject pauseScreenResumeButton, controlsBackButton;
	public GameObject pauseSection, controlsSection;

	bool isPaused;


	EventSystem eS;
	GameManager gM;

	// Use this for initialization
	void Start () {
		eS = FindObjectOfType<EventSystem>();
		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			isPaused = !isPaused;
			if(isPaused){
				Pause();
			} else {
				UnPause();

			}         
		}
	}



	void Pause(){
		pauseScreen.SetActive(true);
		eS.SetSelectedGameObject(pauseScreenResumeButton);
		Time.timeScale = 0;

	}

	public void UnPause(){
		isPaused = false;
		pauseScreen.SetActive(false);
		Time.timeScale = 1;
		eS.SetSelectedGameObject(null);
		pauseSection.SetActive(true);
		controlsSection.SetActive(false);
	}

	public void Controls(){
		pauseSection.SetActive(false);
		controlsSection.SetActive(true);
		eS.SetSelectedGameObject(controlsBackButton);

	}

	public void BackToPauseScreen(){
		pauseSection.SetActive(true);
        controlsSection.SetActive(false);
		eS.SetSelectedGameObject(pauseScreenResumeButton);

	}

	public void BackToMainMenu(){
		gM = FindObjectOfType<GameManager>();
		gM.ResetGame();
		Time.timeScale = 1;
		SceneManager.LoadScene(0);

	}
}
