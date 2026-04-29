using UnityEngine;

public class FallRespawnTrigger : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponentInParent<PlayerHealth>() != null)
        {
            Transform playerRoot = other.GetComponentInParent<PlayerHealth>().transform;

            CharacterController controller = playerRoot.GetComponent<CharacterController>();

            if (controller != null)
                controller.enabled = false;

            playerRoot.position = respawnPoint.position;
            playerRoot.rotation = respawnPoint.rotation;

            if (controller != null)
                controller.enabled = true;
        }
    }
}