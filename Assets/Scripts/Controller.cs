using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;

    private bool player1FlipY;
    private bool player2FlipY;
    
	// Use this for initialization
	void Start () {
        player1FlipY = false;
        player2FlipY = true;

        player1.GetComponent<SpriteRenderer>().flipY = player1FlipY;
        player2.GetComponent<SpriteRenderer>().flipY = player2FlipY;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switchPlayers();
        }
		
	}
    private void switchPlayers()
    {
        // Positions
        Vector3 player1Pos = player1.transform.position;
        player1.transform.position = player2.transform.position;
        player2.transform.position = player1Pos;

        // Gravity
        player1.GetComponent<Rigidbody2D>().gravityScale *= -1;
        player2.GetComponent<Rigidbody2D>().gravityScale *= -1;

        // Sprite
        player1FlipY = !player1FlipY;
        player2FlipY = !player2FlipY;
        player1.GetComponent<SpriteRenderer>().flipY = player1FlipY;
        player2.GetComponent<SpriteRenderer>().flipY = player2FlipY;

    }
}
