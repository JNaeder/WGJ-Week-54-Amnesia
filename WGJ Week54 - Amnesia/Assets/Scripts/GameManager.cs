using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager gM;
	public int currentScene = 0;
	public int completedScene = 0;
    public int inPuzzleOrNot = 0;

	private void Awake()
	{
		
		if(gM != null){
			Destroy(gameObject);
		} else {
			gM = this;
		}

		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {

        
		
	}
	
	// Update is called once per frame
	void Update () {
        


	}
}
