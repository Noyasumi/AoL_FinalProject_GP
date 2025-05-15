using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb2d;

    [SerializeField] int jumpPower = 10;
    [SerializeField] float speed = 8f;
    private Vector2 input;
    private Vector2 lastMoveDirection;
    private bool facingleft = true;
    public bool isGrounded;

    private Vector3 defaultPos;

    private void Awake()
    {
        defaultPos = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ProcessInput();
        Animate();
        if (input.x < 0 && !facingleft || input.x > 0 && facingleft)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Debug.Log("JUMP triggered");
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(input.x * speed, rb2d.velocity.y);
    }

    void ProcessInput()
    {
        float movex = Input.GetAxisRaw("Horizontal");

        if ((movex == 0) && (input.x != 0))
        {
            lastMoveDirection = input;
        }

        input.x = movex;
        input.Normalize();
    }

    void Animate()
    {
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveMagnitude", input.magnitude);
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
    }

    void Flip()
    {
        if (facingleft)
        {
            sr.flipX = true;
        }
        else sr.flipX = false;
    }

    public void CharacterDie()
    {
        transform.position = defaultPos;
    }
}
