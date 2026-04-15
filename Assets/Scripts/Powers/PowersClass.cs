using UnityEngine;

public class PowersClass : MonoBehaviour
{
    public float speed = 5f;

    protected bool isActive = false;

    private GameObject player;
    private GameObject otherPlayer;
    private SpriteRenderer spriteRenderer;

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

    public virtual void ApplyPower(GameObject player, GameObject otherPlayer)
    {
        isActive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            player = collision.gameObject;
            otherPlayer = GameObject.FindGameObjectWithTag("Player2");
            ApplyPower(player, otherPlayer);
            spriteRenderer.enabled = false;
        }

        if (collision.CompareTag("Player2"))
        {
            player = collision.gameObject;
            otherPlayer = GameObject.FindGameObjectWithTag("Player1");
            ApplyPower(player, otherPlayer);
            spriteRenderer.enabled = false;
        }
    }
}
