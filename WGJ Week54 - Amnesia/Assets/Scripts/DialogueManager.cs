using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	Queue<string> sentences;
	public TextMeshProUGUI dialougeText;
	public TextMeshProUGUI nameText;
	public Image pictureImage;
	public Animator anim;
	public Animator transitionAnim;

	GameManager gM;

	bool loadsNextScene;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();

		gM = FindObjectOfType<GameManager>();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Return)){

			DisplayNextSentence();
		}
	}


	public void StartDialouge(Dialogue dialouge){
		anim.SetBool("isOpen", true);
		gM.currentScene = dialouge.sceneToLoad;
		loadsNextScene = dialouge.loadsScene;
		nameText.text = dialouge.name;
		pictureImage.sprite = dialouge.picture;
		sentences.Clear();
		foreach(string sentence in dialouge.sentences){
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}

    

	public void DisplayNextSentence(){
		if(sentences.Count == 0){
			if (loadsNextScene)
			{
				LoadNextScene();
			} else {
				EndDialouge();
			}
			return;
		} else {
			string sentence = sentences.Dequeue();
			StopAllCoroutines();
			StartCoroutine(TypeSentence(sentence));
		}

	}

	public void EndDialouge(){
		Debug.Log("End Convo");
		anim.SetBool("isOpen", false);

	}


	public void LoadNextScene(){
		StartCoroutine(LoadScene());

	}

	IEnumerator LoadScene(){
		transitionAnim.SetTrigger("End");
		yield return new WaitForSeconds(1.0f);
        gM.inPuzzleOrNot = 1;
        SceneManager.LoadScene(gM.currentScene);

	}

	IEnumerator TypeSentence(string sentence){
		dialougeText.text = "";
		foreach(char letter in sentence.ToCharArray()){
			dialougeText.text += letter;
			yield return null;
		}

	}
}
