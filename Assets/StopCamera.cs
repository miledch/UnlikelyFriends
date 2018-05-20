using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCamera : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("I WAS HERE");
        if(collision.gameObject.tag == "Player")
        {
            print("YOU DEAD FOO");
        }
    }
}
