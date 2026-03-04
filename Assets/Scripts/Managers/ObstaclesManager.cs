using System.Collections;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    public Transform spawnPointPlayer1;
    public Transform spawnPointPlayer2;

    private float minSpawnTime = 2.0f;
    private float maxSpawnTime = 5.0f;

    public GameObject[] obstaclesPrefabs;

    void Start()
    {
        SpawnObstaclesPlayer1();
        SpawnObstaclesPlayer2();
    }

    private void SpawnObstaclesPlayer1()
    {
        Instantiate(obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)], spawnPointPlayer1.position, Quaternion.identity);
        float nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("SpawnObstaclesPlayer1", nextSpawnTime);
        maxSpawnTime -= 0.01f;
    }

    private void SpawnObstaclesPlayer2()
    {
        Instantiate(obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)], spawnPointPlayer2.position, Quaternion.identity);
        float nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("SpawnObstaclesPlayer2", nextSpawnTime);
        maxSpawnTime -= 0.01f;
    }
}
