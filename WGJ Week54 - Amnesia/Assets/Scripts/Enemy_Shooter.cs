using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooter : MonoBehaviour {
	public GameObject enemyBall;
	public Transform muzzle;
	public float fireRate;
	public float ballSpeed;

	float shootingTime;

	// Use this for initialization
	void Start () {
		shootingTime = 1 / fireRate;
		InvokeRepeating("ShootBall", 0.01f, shootingTime);
	}




	public void ShootBall(){
		GameObject newBall = Instantiate(enemyBall, muzzle.position, muzzle.rotation);
		EnemyBall ballScript = newBall.GetComponent<EnemyBall>();
		ballScript.speed = ballSpeed;

	}
}
