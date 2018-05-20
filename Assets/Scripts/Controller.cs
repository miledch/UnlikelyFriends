using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject smokePuffs;

    private float player1FlipY;
    private float player2FlipY;


    // Use this for initialization
    void Start()
    {

        player1FlipY = player1.transform.localScale.y;
        player1.transform.localScale = new Vector3(player1.transform.localScale.x, player1FlipY, player1.transform.localScale.z);
        player2FlipY = player2.transform.localScale.y * -1;
        player2.transform.localScale = new Vector3(player2.transform.localScale.x, player2FlipY, player2.transform.localScale.z);

        if (player1.GetComponent<Rigidbody2D>().gravityScale < 0)
        {
            player1.GetComponent<Rigidbody2D>().gravityScale *= -1;
        }

        if (player2.GetComponent<Rigidbody2D>().gravityScale > 0)
        {
            player2.GetComponent<Rigidbody2D>().gravityScale *= -1;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switchPlayers();
            GameObject smokePuff1 = Instantiate(smokePuffs, player1.transform.position, Quaternion.identity) as GameObject;
            GameObject smokePuff2 = Instantiate(smokePuffs, player2.transform.position, Quaternion.identity) as GameObject;
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
        flipSpriteUpsideDown();

    }

    private void flipSpriteUpsideDown()
    {
        player1FlipY = player1FlipY * -1;
        player1.transform.localScale = new Vector3(player1.transform.localScale.x, player1FlipY, player1.transform.localScale.z);
        player2FlipY = player2FlipY * -1;
        player2.transform.localScale = new Vector3(player2.transform.localScale.x, player2FlipY, player2.transform.localScale.z);
    }

}
