using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float xSpeed;
    public float ySpeed;
    public bool secJump = false;
    private bool running;

    //Ground Check variables
    public bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    //Object Variables
    private Rigidbody2D rb2d;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        ySpeed = 15f;
        xSpeed = 5f;
	}
	
	// Update is called once per frame
	void Update () {

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Running", running);


        if (Input.GetKeyDown (KeyCode.Space))
        {
            CharacterJump();
        }

        if (grounded)
        {
            secJump = true;
        }

        if (rb2d.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (rb2d.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            xSpeed = 10f;
        }
        else
        {
            xSpeed = 5f;
        }

        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            rb2d.velocity = new Vector2(-xSpeed, rb2d.velocity.y);
            running = true;
        }
        else if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            rb2d.velocity = new Vector2(xSpeed, rb2d.velocity.y);
            running = true;
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            running = false;
        }

    }



    void CharacterJump()
    {
        if (secJump)
        {
            rb2d.velocity = new Vector2(0, ySpeed);
            secJump = false;
        }
        else if (grounded)
        {
            rb2d.velocity = new Vector2(0, ySpeed);
            secJump = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == ("MovingPlatform"))
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == ("MovingPlatform"))
        {
            transform.parent = null;
        }
    }
}
