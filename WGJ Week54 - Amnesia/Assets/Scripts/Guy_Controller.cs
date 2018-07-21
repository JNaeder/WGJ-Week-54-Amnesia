using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guy_Controller : MonoBehaviour {
	public float speed = 5f;
	public float jumpStrength = 5f;
	public float downMult, upMult;

	Rigidbody2D rB;
	SpriteRenderer sP;

	public GameObject guyClone;
	public float maxSteps;
	public bool isGhosting;
	public bool isGrounded;
	public Transform groundCheck;
	public LayerMask groundMask;

	GameObject newClone;
	Guy_Ghost ghostGuy;
	Vector3 lastRealPos;

	float steps;
	float newX;



	GameManager gM;

	// Use this for initialization
	void Start () {
		rB = GetComponent<Rigidbody2D>();
		sP = GetComponent<SpriteRenderer>();

		gM = FindObjectOfType<GameManager>();

		newClone = null;
	}

	void Update(){
        Ghosting();
		Movement();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		

		CheckGrounded();
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.gameObject.tag == "Enemy")
		{
			if (isGhosting)
			{
			}
			else
			{
				Death();
			}
		}

	}



	public void Death(){
		//transform.position = startPos;
		SceneManager.LoadScene(gM.currentScene);
		Debug.Log("Death!");

	}

	void CheckGrounded(){
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundMask);

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


	void Ghosting(){



		
		if(Input.GetKeyDown(KeyCode.LeftShift)){
			newClone = Instantiate(guyClone, transform.position, Quaternion.identity);

			sP.color = new Color(1, 1, 1, 0.5f);
			lastRealPos = transform.position;
			newX = transform.position.x;
			ghostGuy = newClone.GetComponent<Guy_Ghost>();
			ghostGuy.maxSteps = maxSteps;
			isGhosting = true;
		}

		if (Input.GetKey(KeyCode.LeftShift)){

			if (ghostGuy != null)
			{
				if (Mathf.Abs(newX - transform.position.x) > 1)
				{

					ghostGuy.steps++;
					newX = transform.position.x;
				}


				if(ghostGuy.isGhosting == false){
					Destroy(newClone.gameObject);
                    sP.color = Color.white;
                    transform.position = lastRealPos;
					isGhosting = false;

				}
			}

		}
		if(Input.GetKeyUp(KeyCode.LeftShift)){
			ResetGhost();
		}

	}


	void ResetGhost(){
		isGhosting = false;
        if (ghostGuy != null)
        {
            if (ghostGuy.isGhosting)
            {
                Destroy(newClone.gameObject);
                sP.color = Color.white;
                transform.position = lastRealPos;
            }

        }
        Destroy(newClone.gameObject);

	}
}
