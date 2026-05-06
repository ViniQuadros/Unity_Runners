using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private float speed;

    private void Start()
    {
        GameObject ground = GameObject.FindGameObjectWithTag("Ground");
        speed = ground.GetComponent<FloorMovement>().GetSpeed();
    }

    void Update()
    {
        if (transform.position.x <= -50f)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);
        speed += 0.1f * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl playerControl = collision.GetComponent<PlayerControl>();
        bool canDie = playerControl.PlayerCanDie();

        if (!canDie)
        {
            return;
        }

        string victoryText = "";

        if (collision.CompareTag("Player1"))
        {
            victoryText = "Player 2 Wins!";
        }
        else if (collision.CompareTag("Player2"))
        {
            victoryText = "Player 1 Wins!";
        }

        GameManager.gameManagerInstance.PauseGame();
        GameManager.gameManagerInstance.WhoWins(victoryText);
    }
}
