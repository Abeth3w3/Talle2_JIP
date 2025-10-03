using UnityEngine;

public class WallClimb : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Wall Settings")]
    [SerializeField] private float wallCheckDistance = 0.5f; // Distancia del raycast horizontal
    [SerializeField] private float wallClimbSpeed = 4f;      // Velocidad al escalar
    [SerializeField] private float wallSlideSpeed = -1f;     // Velocidad al deslizarse
    [SerializeField] private LayerMask wallLayer;            // Capa de las paredes

    private bool isTouchingWall;
    private bool isClimbing;
    private float defaultGravity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;
    }

    private void Update()
    {
        
        isTouchingWall = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, wallCheckDistance, wallLayer);

        
        Debug.DrawRay(transform.position, Vector2.right * transform.localScale.x * wallCheckDistance, Color.green);

        
        if (isTouchingWall && Input.GetKey(KeyCode.W))
        {
            StartClimb();
        }
        
        else if (isTouchingWall && Input.GetKey(KeyCode.S))
        {
            WallSlide();
        }
        else
        {
            StopClimb();
        }

    }

    private void StartClimb()
    {
        rb.gravityScale = 0f; 
        rb.linearVelocity = new Vector2(0, wallClimbSpeed); 
        isClimbing = true;
    }

    private void WallSlide()
    {
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(0, wallSlideSpeed); 
        isClimbing = false;
    }

    private void StopClimb()
    {
        rb.gravityScale = defaultGravity; 
        isClimbing = false;
    }
}
