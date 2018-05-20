using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCamera : MonoBehaviour
{
    private CameraMovement cameraMovement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            cameraMovement = this.transform.parent.gameObject.GetComponent<CameraMovement>();
            cameraMovement.StopMovement();
        }
    }
}
