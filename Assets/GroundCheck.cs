using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]  private Movement CharaMovement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharaMovement.isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CharaMovement.isGrounded = false;
    }
}
