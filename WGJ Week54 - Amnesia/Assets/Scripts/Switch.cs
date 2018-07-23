using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public Sprite switchUp, switchDown;
    public GameObject[] puzzleObject;
    public bool destroysObject, turnsOnObject;

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
            sP.sprite = switchDown;
            if (puzzleObject != null)
            {
                if (destroysObject)
                {
                    for (int i = 0; i < puzzleObject.Length; i++) {
                        Destroy(puzzleObject[i]);
                    }
                }
                else if (turnsOnObject) {
                    for (int i = 0; i < puzzleObject.Length; i++)
                    {
                        puzzleObject[i].SetActive(true);

                    }
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
            for (int i = 0; i < puzzleObject.Length; i++)
            {
            if (puzzleObject[i] != null)
            {
                Gizmos.DrawLine(transform.position, puzzleObject[i].transform.position);
            }

            }
            
        
    }
}
