using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	public Sprite buttonDown, buttonUp;

	public GameObject door;

	Guy_Controller guy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player"){
			//Debug.Log("Press Button");
			door.SetActive(false);
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//Debug.Log("Off of Button");
			guy = collision.gameObject.GetComponent<Guy_Controller>();
			if (guy != null)
			{
				if (!guy.isGhosting)
				{
					door.SetActive(true);
				}
			}
		}
	}
}
