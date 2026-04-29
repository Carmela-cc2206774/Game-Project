using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public GameObject controlsUI; // your existing UI object

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            // Start spawning enemies
            if (enemySpawner != null)
                enemySpawner.StartSpawning();

            // Show your existing UI
            // if (controlsUI != null)
            //     controlsUI.SetActive(true);
        }
    }
}