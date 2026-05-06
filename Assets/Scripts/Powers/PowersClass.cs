using UnityEngine;

public class PowersClass : MonoBehaviour
{
    public float speed = 5f;
    public GameObject pickUpEffect;

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
        bool isP1 = collision.CompareTag("Player1");
        bool isP2 = collision.CompareTag("Player2");

        if (isP1 || isP2)
        {
            GetComponent<Collider2D>().enabled = false;
            spriteRenderer.enabled = false;

            GameObject effect = Instantiate<GameObject>(pickUpEffect, transform.position, Quaternion.identity);

            AudioManager.Instance.PlayAudio("PickUp");

            if (isP1)
            {
                player = collision.gameObject;
                otherPlayer = GameManager.gameManagerInstance.GetPlayer2();
            }
            else
            {
                player = collision.gameObject;
                otherPlayer = GameManager.gameManagerInstance.GetPlayer1();
            }

            ApplyPower(player, otherPlayer);

            Destroy(gameObject, 11f);
        }
    }
}
