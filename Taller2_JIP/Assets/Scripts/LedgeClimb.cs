using UnityEngine;

public class LedgeClimb : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Ledge Settings")]
    [SerializeField] private float wallCheckDistance = 0.5f;
    [SerializeField] private float ledgeCheckOffsetY = 1f;
    [SerializeField] private float climbOffsetX = 0.5f;
    [SerializeField] private float climbOffsetY = 1f;
    [SerializeField] private LayerMask wallLayer;

    private bool isTouchingWall;
    private bool isTouchingLedge;
    private bool isClimbingLedge;
    private Vector2 ledgePos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isTouchingWall = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, wallCheckDistance, wallLayer);
        Vector2 ledgeCheckPos = new Vector2(transform.position.x, transform.position.y + ledgeCheckOffsetY);
        isTouchingLedge = !Physics2D.Raycast(ledgeCheckPos, Vector2.right * transform.localScale.x, wallCheckDistance, wallLayer);

        Debug.DrawRay(transform.position, Vector2.right * transform.localScale.x * wallCheckDistance, Color.red);
        Debug.DrawRay(ledgeCheckPos, Vector2.right * transform.localScale.x * wallCheckDistance, Color.blue);

        if (isTouchingWall && isTouchingLedge && !isClimbingLedge)
        {
            ledgePos = transform.position;
            StartCoroutine(ClimbLedge());
        }
    }

    private System.Collections.IEnumerator ClimbLedge()
    {
        isClimbingLedge = true;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;

        animator?.SetTrigger("ledgeClimb");

        yield return new WaitForSeconds(0.5f);

        transform.position = new Vector2(
            ledgePos.x + (transform.localScale.x > 0 ? climbOffsetX : -climbOffsetX),
            ledgePos.y + climbOffsetY
        );

        rb.gravityScale = 1f;
        isClimbingLedge = false;
    }
}
