using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private Rigidbody2D rigidbody2D;
    public float speed = 0.25f;
    public float acceleration = 0.01f;
    float updateVelocity;

    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();

        this.rigidbody2D.velocity += Vector2.right * speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {

        updateVelocity = this.rigidbody2D.velocity.x * acceleration;

        this.rigidbody2D.velocity += Vector2.right * acceleration * Time.deltaTime;


    }


}
