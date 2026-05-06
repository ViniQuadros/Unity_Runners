using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [Header("References")]
    public Transform[] backgrounds;

    private float scrollSpeed;
    private float spriteWidth;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        SpriteRenderer sr = backgrounds[0].GetComponent<SpriteRenderer>();
        // bounds.size.x is always the world-space width regardless of pivot
        spriteWidth = sr.bounds.size.x;

        scrollSpeed = GameObject.FindGameObjectWithTag("Ground")
                                .GetComponent<FloorMovement>()
                                .GetSpeed();
    }

    void Update()
    {
        MoveBackground();
        LoopBackground();
    }

    void MoveBackground()
    {
        foreach (Transform bg in backgrounds)
        {
            bg.position += Vector3.left * scrollSpeed * Time.deltaTime;
        }
        scrollSpeed += 0.1f * Time.deltaTime;
    }

    void LoopBackground()
    {
        float screenLeftEdge = mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect;

        foreach (Transform bg in backgrounds)
        {
            float spriteRightEdge = bg.position.x + spriteWidth * 0.5f;

            if (spriteRightEdge <= screenLeftEdge)
            {
                Transform rightMost = GetRightMostBackground();
                bg.position = new Vector3(
                    rightMost.position.x + spriteWidth,
                    bg.position.y,
                    bg.position.z
                );
            }
        }
    }

    Transform GetRightMostBackground()
    {
        Transform rightMost = backgrounds[0];
        foreach (Transform bg in backgrounds)
        {
            if (bg.position.x > rightMost.position.x)
                rightMost = bg;
        }
        return rightMost;
    }
}