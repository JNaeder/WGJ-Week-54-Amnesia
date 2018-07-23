using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float speed;
	public Vector3 offset;

	OutdoorsManager oM;
	GameManager gM;

	// Use this for initialization
	void Start () {
		oM = FindObjectOfType<OutdoorsManager>();
		gM = FindObjectOfType<GameManager>();

		transform.position = oM.spawnPosition[gM.completedScene].position + offset;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null)
		{
			transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
		}

	}

	public void SetTarget(){
		target = FindObjectOfType<Outside_Guy_Controller>().transform;

	}
}
