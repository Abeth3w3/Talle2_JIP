using System.Runtime.CompilerServices;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public static MovePlayer Instance;

    private Rigidbody2D rb;
    private Animator Animator;
    private float horizontal;
    public float speed;
    public float jumpForce;
    private bool Grounded;
    public float groundCheckRadius;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }


    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        Animator.SetBool("running", horizontal != 0.0f);
        Animator.SetBool("jumping", !Grounded);


        if (horizontal < 0.0f) transform.localScale = new Vector3(-4.828462f, 4.726093f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(4.828462f, 4.726093f, 1.0f);

        Debug.DrawRay(transform.position, Vector3.down * groundCheckRadius, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, groundCheckRadius))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {

            Jump();
        }
    }
    private void Jump()

    {
        rb.AddForce(Vector2.up * jumpForce);

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
}
