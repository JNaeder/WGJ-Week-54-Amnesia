using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ButtonScript : MonoBehaviour {

	public Sprite buttonDown, buttonUp;

	public GameObject[] puzzleObject;
    public LayerMask mask;

    [FMODUnity.EventRef]
    public string buttonDownSound, buttonUpound;

    bool isPressed;

	Guy_Controller guy;
    SpriteRenderer sP;
	// Use this for initialization
	void Start () {
        sP = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (puzzleObject != null)
        {
            if (Physics2D.OverlapBox(transform.position, Vector2.one * 0.5f, 0, mask))
            {
                if (!isPressed)
                {
                    isPressed = true;
                    for (int i = 0; i < puzzleObject.Length; i++) {
                        puzzleObject[i].SetActive(false);
                    }
                    sP.sprite = buttonDown;
                    FMODUnity.RuntimeManager.PlayOneShot(buttonDownSound);
                }
            }
            else
            {
                if (isPressed)
                {
                    isPressed = false;
                    for (int i = 0; i < puzzleObject.Length; i++)
                    {
                        if (puzzleObject[i] != null)
                        {
                            puzzleObject[i].SetActive(true);
                        }
                    }
                    sP.sprite = buttonUp;
                    FMODUnity.RuntimeManager.PlayOneShot(buttonUpound);
                }
            }
        }
        else {
            sP.sprite = buttonDown;

        }
		
	}


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        for (int i = 0; i < puzzleObject.Length; i++)
        {
            if (puzzleObject[i] != null)
            {
                Gizmos.DrawLine(transform.position, puzzleObject[i].transform.position);
            }

        }


    }


}
