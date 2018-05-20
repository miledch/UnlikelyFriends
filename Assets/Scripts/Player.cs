using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {

    private Rigidbody2D rb2d;
    public bool player1;
    public float jumpHeight;
    private bool grounded;
    public float moveSpeed;

    private float horizontalInput;

    private Animator animator;


    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	void LateUpdate ()
    {
        if(player1)
        {
            horizontalInput = Input.GetAxis("HorizontalPlayer1");
            if (horizontalInput > 0 || horizontalInput < 0)
            {
                animator.SetBool("isRunning", true);
                Flip();
            }
            else if (horizontalInput == 0)
            {
                animator.SetBool("isRunning", false);
            }
        }
        else 
        {
            horizontalInput = Input.GetAxis("HorizontalPlayer2");
            if (horizontalInput > 0 || horizontalInput < 0)
            {
                animator.SetBool("isRunning", true);
                Flip();
            }
            else if (horizontalInput == 0)
            {
                animator.SetBool("isRunning", false);
            }
        }
    }

    private void Update()
    {
        if(player1)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                jump();
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jump();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
        }
    }

    private void Flip()
    {
        if (horizontalInput < 0)
        {
            if (this.transform.localScale.x > 0)
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, 1);
            }
        }
        if (horizontalInput > 0)
        {
            if (this.transform.localScale.x < 0)
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, 1);
            }
        }
    }
    private void jump()
    {
        if (grounded)
        {
            animator.Play("Jump");
            if (rb2d.gravityScale < 0)
            {
                rb2d.AddForce(Vector2.down * jumpHeight);
            }
            else
            {
                rb2d.AddForce(Vector2.up * jumpHeight);
            }
            
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Floor"))
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("rearCamera"))
        {
            animator.SetBool("isDead", true);
        }
    }

}
