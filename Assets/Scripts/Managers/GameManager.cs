using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject characterSelectorP1Canvas;
    public GameObject characterSelectorP2Canvas;

    public TextMeshProUGUI P1Confirmed;
    public TextMeshProUGUI P2Confirmed;

    public GameObject playerWinCanvas;
    public TextMeshProUGUI playerWinText;

    public static GameManager gameManagerInstance { get; private set; }

    private bool player1ready = false;
    private bool player2ready = false;

    private GameObject player1;
    private GameObject player2;

    private void Awake()
    {
        if (gameManagerInstance != null && gameManagerInstance != this)
        {
            Destroy(gameObject);
            return;
        }

        gameManagerInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void BeginGame()
    {
        if (player1ready && player2ready)
        {
            characterSelectorP1Canvas.SetActive(false);
            characterSelectorP2Canvas.SetActive(false);
            ResumeGame();
        }
    }

    public void Player1Ready()
    {
        if (!player1ready)
        {
            player1ready = true;
            P1Confirmed.gameObject.SetActive(true);
            BeginGame();
        }
    }

    public void Player2Ready()
    {
        if (!player2ready)
        {
            player2ready = true;
            P2Confirmed.gameObject.SetActive(true);
            BeginGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WhoWins(string victoryText)
    {
        playerWinCanvas.SetActive(true);
        playerWinText.text = victoryText;
    }

    public GameObject GetPlayer1()
    {
        return player1;
    }

    public GameObject GetPlayer2()
    {
        return player2;
    }
}
