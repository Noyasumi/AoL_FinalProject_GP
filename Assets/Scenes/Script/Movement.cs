using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float direction;
    private float speed = 8f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        UpdatePosition();
        SetDirection(Input.GetAxisRaw("Horizontal");
    }

    private void UpdatePosition()
    {
        Vector2 velocity = rb2d.velocity;
        velocity.x = direction * speed;
        rb2d.velocity = velocity;
    }

    private void SetDirection(float direction)
    {
        this.direction = direction;
    }
}
