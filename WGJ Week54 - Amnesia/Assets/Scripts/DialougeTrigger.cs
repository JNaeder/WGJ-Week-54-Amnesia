using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public Dialogue endDialogue;
	public Dialogue preLevelDialogue;
	public Dialogue postLevelDialogue;

	DialogueManager dM;
	GameManager gM;
	SpriteRenderer sP;

	public int comlpetedSceneNum;
	public Sprite shadowSprite;

	Sprite startSprite;

	private void Start()
	{
		dM = FindObjectOfType<DialogueManager>();
		gM = FindObjectOfType<GameManager>();
		sP = GetComponentInParent<SpriteRenderer>();
		startSprite = sP.sprite;
	}

	private void Update()
	{
		if(gM.completedScene < comlpetedSceneNum){
			sP.sprite = shadowSprite;
		} else {
			sP.sprite = startSprite;
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(gM.completedScene < comlpetedSceneNum){
			dM.StartDialouge(preLevelDialogue);
		} else if(gM.completedScene == comlpetedSceneNum){
			dM.StartDialouge(dialogue);
		} else if(gM.completedScene == comlpetedSceneNum + 1){
			dM.StartDialouge(endDialogue);
		}
		else if (gM.completedScene > comlpetedSceneNum + 1)
        {
			dM.StartDialouge(postLevelDialogue);
        }
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		dM.EndDialouge();
	}
}
