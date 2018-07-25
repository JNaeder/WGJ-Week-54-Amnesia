using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutdoorsManager : MonoBehaviour {

	public GameObject guy;
	public Transform[] spawnPosition;

	int numberOfPos;

	GameManager gM;
	CameraFollow cam;

	// Use this for initialization
	void Start () {
		gM = FindObjectOfType<GameManager>();
		cam = Camera.main.GetComponent<CameraFollow>();
		Debug.Log(gM.name);
		Instantiate(guy, spawnPosition[gM.completedScene].position, Quaternion.identity);
		cam.SetTarget();
	}

}
