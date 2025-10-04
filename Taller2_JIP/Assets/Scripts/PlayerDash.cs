using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator Animator;
    private MovePlayer player;

    [Header("Dash Settings")]
    [SerializeField] private float dashPowerHorizontal = 20f;
    [SerializeField] private float dashPowerVertical = 15f;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float dashCooldown = 0.5f;
    [SerializeField] private int maxAirDashes = 1;

    public bool isDashing;
    private bool canDash = true;
    private int airDashesRemaining;

    private float baseGravity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        player = GetComponent<MovePlayer>();
        baseGravity = rb.gravityScale;
        airDashesRemaining = maxAirDashes;
    }

    private void Update()
    {
        Animator.SetBool("dashing", !canDash);

        if (IsGrounded())
        {
            airDashesRemaining = maxAirDashes;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && airDashesRemaining > 0)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if (x == 0 && y == 0)
                x = transform.localScale.x > 0 ? 1 : -1;

            Vector2 dashDir = new Vector2(x, y).normalized;
            StartCoroutine(Dash(dashDir));
        }
    }

    private IEnumerator Dash(Vector2 dir)
    {
        canDash = false;
        isDashing = true;
        airDashesRemaining--;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        player.enabled = false;
        rb.linearVelocity = Vector2.zero;

        Vector2 dashVelocity;

        if (dir.y == 0)
            dashVelocity = new Vector2(dir.x * dashPowerHorizontal, 0);
        else if (dir.x == 0)
            dashVelocity = new Vector2(0, dir.y * dashPowerVertical);
        else
            dashVelocity = new Vector2(dir.x * dashPowerHorizontal, dir.y * dashPowerVertical).normalized *
                           ((dashPowerHorizontal + dashPowerVertical) / 2f);

        rb.linearVelocity = dashVelocity;

        yield return new WaitForSeconds(dashTime);

        rb.gravityScale = originalGravity;
        isDashing = false;

        player.enabled = true;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, player.groundCheckRadius);
    }
}
