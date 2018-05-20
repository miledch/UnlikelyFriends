using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public AudioClip deathSound;
    private Rigidbody2D rb2d;
    public bool player1;
    public float jumpHeight;
    private bool grounded;
    public float moveSpeed;

    public int maxDeaths = 3;
    static int numDeaths;

    private float horizontalInput;
    private bool gameOver;
    private float xMax = 0.0f;
    float distance;



    private Animator animator;


    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        distance = transform.position.z - Camera.main.transform.position.z;
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
        if(player1 && !gameOver)
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
        else if(!gameOver)
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
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x;
        float newX = Mathf.Clamp(transform.position.x, transform.position.x, (xMax - 0.3f));
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
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
        if (grounded && !gameOver)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("deadlyObject"))
        {
            death(collision.transform.position);
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

            death(collision.transform.position);
        }
    }

    private void RestartLevel(bool lose)
    {
        if (lose)
        {
            StartCoroutine("WaitLose");
        }
        else
        {
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        gameOver = false;
    }

    private void death(Vector3 soundPosition)
    {
        animator.SetBool("isDead", true);
        numDeaths++;
        AudioSource.PlayClipAtPoint(deathSound, soundPosition);
        if (numDeaths >= maxDeaths)
        {
            numDeaths = 0;
            //SceneManager.LoadScene("Lose");
            RestartLevel(true);
        }
        gameOver = true;
        RestartLevel(false);
    }

    IEnumerator WaitLose()
    {
        yield return new WaitForSeconds(2);
        print("loading lose");
        String name = "Lose";
        SceneManager.LoadScene(name);
        //gameOver = false;
    }
}
