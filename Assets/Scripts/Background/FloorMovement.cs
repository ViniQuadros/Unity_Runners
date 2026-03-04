using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorMovement : MonoBehaviour
{
    public float speed = 5f;

    private Tilemap tilemap;
    private float tileSize;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tileSize = tilemap.localBounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= -tileSize)
        {
            transform.position += Vector3.right * tileSize * 2f;
        }

        speed += 0.1f * Time.deltaTime;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
