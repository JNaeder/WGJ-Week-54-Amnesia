using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Outside_Guy_Controller : MonoBehaviour {
	public float speed = 5f;
	public float jumpStrength = 5f;
	public float downMult, upMult;

	public Transform groundCheck, sideCheckLeft, sideCheckRight;

	bool isGrounded, isTouchingSideLeft, isTouchingSideRight;

	public LayerMask groundMask;

    [FMODUnity.EventRef]
    public string jumpSound;

	Rigidbody2D rB;
	Animator anim;

	// Use this for initialization
	void Start () {
		rB = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		Movement();
		Checks();
	}


	void Checks(){
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundMask);
		isTouchingSideLeft = Physics2D.OverlapCircle(sideCheckLeft.position, 0.25f, groundMask);
		isTouchingSideRight = Physics2D.OverlapCircle(sideCheckRight.position, 0.25f, groundMask);


	}


	void Movement(){
		float h = Input.GetAxis("Horizontal");
		anim.SetFloat("h", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
		anim.SetBool("isGrounded", isGrounded);

		if(isTouchingSideLeft){
			if(h < 0){
				h = 0;
			}
		} else if(isTouchingSideRight){
			if( h > 0){
				h = 0;
			}
		}


        transform.position += new Vector3(h * speed * Time.deltaTime, 0, 0);

        if (Input.GetButtonDown("Jump"))
        {
			if (isGrounded)
			{
                FMODUnity.RuntimeManager.PlayOneShot(jumpSound);
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



}
