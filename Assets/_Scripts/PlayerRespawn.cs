using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint;

    private PlayerHealth health;
    private CharacterController controller;

    private void Start()
    {
        health = GetComponent<PlayerHealth>();
        controller = GetComponent<CharacterController>();

        if (health != null)
        {
            health.OnDeath += Respawn;
        }
    }


void Respawn()
{
    Debug.Log("Respawning...");

    if (controller != null)
        controller.enabled = false;

    transform.position = respawnPoint.position;

    if (controller != null)
        controller.enabled = true;

    health.ResetHealth();

    // 🔥 FORCE animator to Idle
    Animator anim = GetComponent<Animator>();
    if (anim != null)
    {
        anim.Rebind();       // resets animator state
        anim.Update(0f);     // applies it immediately
    }
}
    // void Respawn()
    // {
    //     Debug.Log("Respawning...");

    //     if (controller != null)
    //         controller.enabled = false;

    //     transform.position = respawnPoint.position;

    //     if (controller != null)
    //         controller.enabled = true;

    //     health.ResetHealth();
    // }
}