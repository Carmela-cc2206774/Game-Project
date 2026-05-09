using UnityEngine;

public class RespawnCheckpoint : MonoBehaviour
{
    [SerializeField] private Transform checkpointRespawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        PlayerRespawn respawn = other.GetComponentInParent<PlayerRespawn>();

        if (respawn == null) return;

        respawn.SetRespawnPoint(checkpointRespawnPoint);
    }
}