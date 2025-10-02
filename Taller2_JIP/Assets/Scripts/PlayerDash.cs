using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D rb;
    private MovePlayer player;

    [Header("Dash Settings")]
    [SerializeField] private float dashPower = 20f;     // velocidad del dash
    [SerializeField] private float dashTime = 0.2f;     // duración del dash
    [SerializeField] private float dashCooldown = 0.5f; // tiempo entre dashes
    [SerializeField] private int maxAirDashes = 1;      // dashes permitidos en el aire

    private bool isDashing;
    private bool canDash = true;
    private int airDashesRemaining;

    private float baseGravity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<MovePlayer>();
        baseGravity = rb.gravityScale;
        airDashesRemaining = maxAirDashes;
    }

    private void Update()
    {
        // 🔄 reset de dashes al tocar el suelo
        if (IsGrounded())
        {
            airDashesRemaining = maxAirDashes;
        }

        // input del dash (ej: Shift)
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && airDashesRemaining > 0)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            // si no hay input, dash hacia donde mira
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

        rb.linearVelocity = dir * dashPower;

        yield return new WaitForSeconds(dashTime);

        rb.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, player.groundCheckRadius);
    }
}
