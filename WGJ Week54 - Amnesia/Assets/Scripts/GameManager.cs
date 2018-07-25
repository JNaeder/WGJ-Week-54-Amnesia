using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager gM;
	public int currentScene = 0;
	public int completedScene = 0;
    public int inPuzzleOrNot = 0;

	private void Awake()
	{
		
		if (gM != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gM = this;
        }

        DontDestroyOnLoad(this.gameObject);
	}


	public void ResetGame(){
		currentScene = 0;
		completedScene = 0;
		inPuzzleOrNot = 0;


	}




}
