using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode jumpButton;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool jumpPressed;
    private bool canDie = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpButton))
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        bool isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            AudioManager.Instance.PlayAudio("Jump");
        }

        jumpPressed = false;
    }

    public void EnableDeath(bool playerCanDie)
    {
        canDie = playerCanDie;

        if (!canDie) //Invincible
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        }
        else //Vulnerable
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public bool PlayerCanDie()
    {
        return canDie;
    }
}
