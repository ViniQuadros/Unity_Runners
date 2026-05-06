using System.Collections;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [Header("Spawn Points")]
    public Transform spawnPointPlayer1;
    public Transform spawnPointPlayer2;

    [Header("Settings")]
    public GameObject[] obstaclesPrefabs;
    public float minSpawnTime = 2.0f;
    public float maxSpawnTime = 5.0f;
    public float difficultySpike = 0.1f;
    public float minPossibleMaxTime = 0.5f;

    void Start()
    {
        StartCoroutine(SpawnRoutine(spawnPointPlayer1));
        StartCoroutine(SpawnRoutine(spawnPointPlayer2));
    }

    private IEnumerator SpawnRoutine(Transform point)
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            SpawnObstacle(point);

            maxSpawnTime = Mathf.Max(maxSpawnTime - difficultySpike, minPossibleMaxTime);
        }
    }

    private void SpawnObstacle(Transform point)
    {
        if (obstaclesPrefabs.Length == 0) return;

        int index = Random.Range(0, obstaclesPrefabs.Length);
        Instantiate(obstaclesPrefabs[index], point.position, Quaternion.identity);
    }
}