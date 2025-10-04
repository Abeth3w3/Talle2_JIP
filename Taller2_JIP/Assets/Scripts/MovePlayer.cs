using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject BulletPrefab;
    public static MovePlayer Instance;

    private Rigidbody2D rb;
    private Animator Animator;
    private float horizontal;
    public float speed;
    public float jumpForce;
    private bool Grounded;
    private bool OnWall;
    public float groundCheckRadius;
    private float LastShoot;


    [Header("Detección de suelo y paredes")]
    public LayerMask groundLayer;
    public LayerMask wallLayer;

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

        if (horizontal < 0.0f)
            transform.localScale = new Vector3(-4.828462f, 4.726093f, 1.0f);
        else if (horizontal > 0.0f)
            transform.localScale = new Vector3(4.828462f, 4.726093f, 1.0f);

        // Raycast suelo
        bool hitDown = Physics2D.Raycast(transform.position, Vector2.down, groundCheckRadius, groundLayer);

        // Raycast paredes
        bool hitLeft = Physics2D.Raycast(transform.position, Vector2.left, groundCheckRadius, wallLayer);
        bool hitRight = Physics2D.Raycast(transform.position, Vector2.right, groundCheckRadius, wallLayer);

        Debug.DrawRay(transform.position, Vector2.down * groundCheckRadius, Color.red);
        Debug.DrawRay(transform.position, Vector2.left * groundCheckRadius, Color.green);
        Debug.DrawRay(transform.position, Vector2.right * groundCheckRadius, Color.blue);

        // Verifica suelo y pared por separado
        Grounded = hitDown;
        OnWall = hitLeft || hitRight;

        // Permite salto tanto en suelo como en pared
        if (Input.GetKeyDown(KeyCode.Space) && (Grounded || OnWall))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.F) && Grounded)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        Animator.SetTrigger("shooting");
        Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity); 
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
}
