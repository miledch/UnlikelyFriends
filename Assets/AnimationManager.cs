using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer[] sprites;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }


    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            animator.Play("Jump");
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                
            }
        }

    }
}
