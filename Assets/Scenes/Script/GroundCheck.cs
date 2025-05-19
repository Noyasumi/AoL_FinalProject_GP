using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]  private PlayerScript CharaMovement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharaMovement.isGrounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CharaMovement.isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CharaMovement.isGrounded = false;
    }
}
