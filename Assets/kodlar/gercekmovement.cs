using UnityEngine;
using UnityEngine.InputSystem;

public class gercekmovement : MonoBehaviour
{
    public float hizlar = 5f;
    public float ziplama = 8f;

    private Rigidbody2D rb;
    private movementlarprodur inputHandler;

    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<movementlarprodur>();
    }

    private void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.wKey.wasPressedThisFrame &&
            isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, ziplama);
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = inputHandler.Getmovementvectornormalized();
        rb.velocity = new Vector2(moveInput.x * hizlar, rb.velocity.y);
    }

    // YERDEN DEĞME (SADECE ALTINDAN)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
            return;

        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }
}
