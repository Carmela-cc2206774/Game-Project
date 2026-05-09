using UnityEngine;

public class FallRespawnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerRespawn respawn = other.GetComponentInParent<PlayerRespawn>();

        if (respawn == null) return;

        respawn.ShowRespawnPopup();
    }
}