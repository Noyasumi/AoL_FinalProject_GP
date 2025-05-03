using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    private Vector2 lastMoveDirection;
    private bool facingleft = true;

    
    private Rigidbody2D rb2d;
    private Vector2 input;
    private float speed = 8f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ProcessInput();
        Animate();
        Flip();
    }
    private void FixedUpdate()
    {
        rb2d.velocity = input * speed;
    }

    void ProcessInput()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");
        if ((movex == 0 && movey ==0) && (input.x != 0 || input.y != 0))
        {
            lastMoveDirection = input;
        }
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();
    }

    void Animate()
    {
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);
        anim.SetFloat("MoveMagnitude", input.magnitude);
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
    }

    void Flip()
    {
        if(facingleft)
        {
            sr.flipX = true;
        }
        else sr.flipX = false;
    }
}

