using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D rb2d;
    public bool player1;
    public float jumpHeight;
    private bool grounded; 

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if(player1)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                jump();
            }

        } else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jump();
            }
        }
    }

    private void jump()
    {
        if (grounded)
        {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("floor"))
        {
            grounded = true;
        }
         
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("floor"))
        {
            grounded = false;
        }
    }
}
