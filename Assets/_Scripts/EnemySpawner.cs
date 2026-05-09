using System.Collections;
using UnityEngine;

[System.Serializable]
public class SpawnPointData
{
    public Transform point;
    public int maxSpawnCount = 3;

    [HideInInspector]
    public int currentSpawned = 0;
}

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public SpawnPointData[] spawnPoints;

    public float spawnInterval = 2f;

    private bool hasStarted = false;

    public void StartSpawning()
    {
        if (hasStarted) return;

        hasStarted = true;
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0)
            return;

        // Find available spawn points
        var availablePoints = new System.Collections.Generic.List<SpawnPointData>();

        foreach (var spawnPoint in spawnPoints)
        {
            if (spawnPoint.currentSpawned < spawnPoint.maxSpawnCount)
            {
                availablePoints.Add(spawnPoint);
            }
        }

        // No available spawn points
        if (availablePoints.Count == 0)
        {
            Debug.Log("All spawn points reached max.");
            return;
        }

        // Pick random available point
        SpawnPointData selected =
            availablePoints[Random.Range(0, availablePoints.Count)];

        GameObject enemy = Instantiate(
            enemyPrefab,
            selected.point.position,
            selected.point.rotation
        );

        selected.currentSpawned++;

        // Decrease count when enemy dies
        EnemyHealth health = enemy.GetComponent<EnemyHealth>();

        if (health != null)
        {
            health.OnEnemyDeath += () =>
            {
                selected.currentSpawned--;
            };
        }
    }
}
// using System.Collections;
// using UnityEngine;

// public class EnemySpawner : MonoBehaviour
// {
//     public GameObject enemyPrefab;
//     public Transform[] spawnPoints;

//     public int maxEnemies = 5;
//     public float spawnInterval = 2f;

//     private int spawnedCount = 0;
//     private bool hasStarted = false;

//     public void StartSpawning()
//     {
//         if (hasStarted) return;

//         hasStarted = true;
//         StartCoroutine(SpawnRoutine());
//     }

//     IEnumerator SpawnRoutine()
//     {
//         while (spawnedCount < maxEnemies)
//         {
//             SpawnEnemy();
//             spawnedCount++;

//             yield return new WaitForSeconds(spawnInterval);
//         }
//     }

//     void SpawnEnemy()
//     {
//         if (enemyPrefab == null || spawnPoints.Length == 0) return;

//         int index = Random.Range(0, spawnPoints.Length);
//         Transform spawnPoint = spawnPoints[index];

//         Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
//     }
// }