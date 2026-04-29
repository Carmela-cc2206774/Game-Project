using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public int maxEnemies = 5;
    public float spawnInterval = 2f;

    private int spawnedCount = 0;
    private bool hasStarted = false;

    public void StartSpawning()
    {
        if (hasStarted) return;

        hasStarted = true;
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (spawnedCount < maxEnemies)
        {
            SpawnEnemy();
            spawnedCount++;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0) return;

        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}