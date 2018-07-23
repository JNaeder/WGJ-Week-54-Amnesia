using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour {
	
	public int sceneToLoad = 0;
	public Animator transitionAnim;

	bool isTriggered;

	GameManager gM;

	// Use this for initialization
	void Start () {
		gM = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player"){
			if (!isTriggered)
			{
				Guy_Controller guy = collision.gameObject.GetComponent<Guy_Controller>();
				if (!guy.isGhosting)
				{               
					isTriggered = true;
					gM.completedScene++;
					StartCoroutine(LoadScene());
				}
			}
		}
	}


	IEnumerator LoadScene(){
		transitionAnim.SetTrigger("End");
		gM.inPuzzleOrNot = 0;
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene(sceneToLoad);
	}
}
