using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour {
	[HideInInspector]
	public float speed;

	// Use this for initialization
	void Start () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
        

        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
		transform.position += transform.up * Time.deltaTime * speed;
		
	}
}
