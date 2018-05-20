using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            Player playerCollision = collision.gameObject.GetComponent<Player>();

            if(!playerCollision.player1)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
