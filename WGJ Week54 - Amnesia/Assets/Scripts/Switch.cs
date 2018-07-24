using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Switch : MonoBehaviour {

    public Sprite switchUp, switchDown;
    public GameObject[] puzzleObject;
    public bool destroysObject, turnsOnObject, isOneWay, isSwitched;

    [FMODUnity.EventRef]
    public string switchSound;

    SpriteRenderer sP;

	// Use this for initialization
	void Start () {
        sP = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {

			if(isOneWay){
                
                DestoryOrCreateObjects();
			} else if(!isOneWay){            
				TurnOnAndOffSwitch();            
			}


        }
    }

	void TurnOnAndOffSwitch(){
		if(!isSwitched){
            //press down switch
           

            sP.sprite = switchDown;
			isSwitched = true;
			if (destroysObject)
			{
				for (int i = 0; i < puzzleObject.Length; i++)
				{
					puzzleObject[i].SetActive(false);
				}
			} else if(turnsOnObject){
				for (int i = 0; i < puzzleObject.Length; i++)
                {
                    puzzleObject[i].SetActive(true);
                }
			}

		} else {
			//press up switch
			sP.sprite = switchUp;
			isSwitched = false;
			if (destroysObject)
            {
                for (int i = 0; i < puzzleObject.Length; i++)
                {
                    puzzleObject[i].SetActive(true);
                }
            }
            else if (turnsOnObject)
            {
                for (int i = 0; i < puzzleObject.Length; i++)
                {
                    puzzleObject[i].SetActive(false);
                }
            }
            
		}





	}

	void DestoryOrCreateObjects(){

		sP.sprite = switchDown;
		sP.color = Color.grey;
        if (!isSwitched) {
            PlaySwitchSound();
        }

        isSwitched = true;
        if (puzzleObject != null)
        {
            if (destroysObject)
            {
               
                for (int i = 0; i < puzzleObject.Length; i++)
                {
                    Destroy(puzzleObject[i]);
                }
            }

            else if (turnsOnObject)
            {
                
                for (int i = 0; i < puzzleObject.Length; i++)
                {
                    puzzleObject[i].SetActive(true);

                }
            }
        }

	}


    void PlaySwitchSound() {
        FMODUnity.RuntimeManager.PlayOneShot(switchSound);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (!isOneWay)
        {
            Gizmos.color = Color.green;
        }

        for (int i = 0; i < puzzleObject.Length; i++)
            {
            if (puzzleObject[i] != null)
            {
                Gizmos.DrawLine(transform.position, puzzleObject[i].transform.position);
            }

            }

		
            
        
    }
}
