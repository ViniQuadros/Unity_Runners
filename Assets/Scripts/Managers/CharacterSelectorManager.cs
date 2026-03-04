using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectorManager : MonoBehaviour
{
    public Sprite[] characterSprites;
    public Image characterSelector;
    public SpriteRenderer playerSpriteRenderer;

    private int currentIndex = 0;
    private bool canSelect = true;

    private void Start()
    {
        currentIndex = Random.Range(0, characterSprites.Length);
        characterSelector.sprite = characterSprites[currentIndex];
    }

    public void MoveRight()
    {
        if (canSelect)
        {
            if (currentIndex + 1 < characterSprites.Length)
            {
                currentIndex++;
                characterSelector.sprite = characterSprites[currentIndex];
            }
            else
            {
                currentIndex = 0;
                characterSelector.sprite = characterSprites[currentIndex];
            }
        }
    }

    public void MoveLeft()
    {
        if (canSelect)
        {
            if (currentIndex - 1 >= 0)
            {
                currentIndex--;
                characterSelector.sprite = characterSprites[currentIndex];
            }
            else
            {
                currentIndex = characterSprites.Length - 1;
                characterSelector.sprite = characterSprites[currentIndex];
            }
        }
    }

    public void SelectCharacter(GameObject player)
    {
        playerSpriteRenderer.sprite = characterSprites[currentIndex];
        canSelect = false;

        if (player.CompareTag("Player1"))
        {
            GameManager.gameManagerInstance.Player1Ready();
        }
        else if (player.CompareTag("Player2"))
        {
            GameManager.gameManagerInstance.Player2Ready();
        }
    }
}
