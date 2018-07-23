using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy_Ghost : MonoBehaviour {

	public Transform ghostBar;
	public float maxSteps;
	[HideInInspector]
	public float steps;
	public bool isGhosting = true;

    float ghostBarStartSize;
	float ghostBarPerc;

	// Use this for initialization
	void Start () {
		ghostBarStartSize = ghostBar.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {


		ghostBarPerc =  1 - (steps / maxSteps);
		ghostBar.localScale = new Vector3(ghostBarPerc * ghostBarStartSize, ghostBar.localScale.y, 1);

		if(steps >= maxSteps){
			isGhosting = false;
		}
		
	}
}
