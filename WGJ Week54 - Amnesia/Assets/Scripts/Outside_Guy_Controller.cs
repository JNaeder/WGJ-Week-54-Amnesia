using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outside_Guy_Controller : MonoBehaviour {
	public float speed = 5f;
	public float jumpStrength = 5f;
	public float downMult, upMult;

	bool isGrounded;

	Rigidbody2D rB;

	// Use this for initialization
	void Start () {
		rB = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Movement();
	}


	void Movement(){
		float h = Input.GetAxis("Horizontal");

        transform.position += new Vector3(h * speed * Time.deltaTime, 0, 0);

        if (Input.GetButtonDown("Jump"))
        {
			if (isGrounded)
			{
				rB.velocity = new Vector2(rB.velocity.x, 0);
				rB.AddForce(Vector2.up * jumpStrength * 100);
			}

        }

        if (rB.velocity.y < 0)
        {
            rB.velocity += Vector2.up * Physics2D.gravity.y * downMult * Time.deltaTime;

        }
        else if (rB.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rB.velocity += Vector2.up * Physics2D.gravity.y * upMult * Time.deltaTime;

        }

	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		isGrounded = true;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		isGrounded = false;
	}
}
