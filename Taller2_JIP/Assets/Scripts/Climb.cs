using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class escalar : MonoBehaviour
{
    Rigidbody2D rb;
    private bool contacto;
    private float vertical;
    private float X;
    [SerializeField] private float velocidad;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        X = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        agarre();
    }
    public void agarre()
    {
        if (Input.GetKey(KeyCode.LeftShift) && contacto)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            vertical = Input.GetAxisRaw("Vertical");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vertical * velocidad);
            rb.gravityScale = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.gravityScale = X;
            contacto = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("escalable"))
        {
            contacto = true;
        }
    }
}