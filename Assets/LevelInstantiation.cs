using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInstantiation : MonoBehaviour
{

    private GameObject level;
    private GameObject clone;

    private void Start()
    {
        level = this.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (clone)
            {
                Destroy(clone);
            }
            clone = Instantiate(level, new Vector3(transform.position.x + 220, transform.position.y, transform.position.z), Quaternion.identity);
            clone.transform.parent = GameObject.FindGameObjectWithTag("container").transform;
        }
    }
}
