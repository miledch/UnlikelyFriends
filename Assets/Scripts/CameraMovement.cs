using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private new Rigidbody2D rigidbody2D;
    public float speed = 0.25f;
    public float acceleration = 0.01f;

    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();

        //rigidbody2D.velocity += Vector2.right * speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.rigidbody2D.velocity += Vector2.right * acceleration * Time.deltaTime;
    }

    public void StopMovement()
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }


}
