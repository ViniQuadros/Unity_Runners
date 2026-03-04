using UnityEngine;

public class PowersClass : MonoBehaviour
{
    private GameObject player;
    public float speed = 5f;
    private SpriteRenderer spriteRenderer;
    protected bool isActive = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (transform.position.x <= -50f && !isActive)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public virtual void ApplyPower(GameObject player)
    {
        isActive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            player = collision.gameObject;
            ApplyPower(player);
            spriteRenderer.enabled = false;
        }

        if (collision.CompareTag("Player2"))
        {
            player = collision.gameObject;
            ApplyPower(player);
            spriteRenderer.enabled = false;
        }
    }
}
