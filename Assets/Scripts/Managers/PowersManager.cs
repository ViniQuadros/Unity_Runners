using UnityEngine;

public class PowersManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] powerupPrefab;

    void Start()
    {
        Invoke(nameof(SpawnPowers), Random.Range(5f, 10f));
    }

    private void SpawnPowers()
    {
        Transform currentSpawn = spawnPoints[Random.Range(0,spawnPoints.Length)];
        GameObject prefab = powerupPrefab[Random.Range(0, powerupPrefab.Length)];

        Instantiate(prefab, currentSpawn.position, Quaternion.identity);
        Invoke(nameof(SpawnPowers), Random.Range(15f, 30f));
    }
}
