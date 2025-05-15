using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool movingUp;
    [SerializeField] private float speed;

    private void Start()
    {
        movingUp = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(movingUp)
        {
            movingUp = false;
        }
        else
        {
            movingUp = true;
        }
    }

    private void Update()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }
        else
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }

    }
}
