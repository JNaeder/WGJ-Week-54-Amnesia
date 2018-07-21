using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public Sprite switchUp, switchDown;
    public GameObject door;

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
            if (door != null)
            {
                Destroy(door);
            }
        }
    }
}
