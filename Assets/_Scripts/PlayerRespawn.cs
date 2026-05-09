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
            health.OnDeath += ShowRespawnPopup;
    }

    public void ShowRespawnPopup()
    {
        RespawnPopupUI.instance.ShowPopup(this);
    }

    public void Respawn()
    {
        Debug.Log("Respawning...");

        if (controller != null)
            controller.enabled = false;

        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        if (controller != null)
            controller.enabled = true;

        if (health != null)
            health.ResetHealth();

        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.Rebind();
            anim.Update(0f);
        }
    }

    public void SetRespawnPoint(Transform newPoint)
    {
        respawnPoint = newPoint;
        Debug.Log("Respawn point updated to: " + newPoint.name);
    }
}

// using UnityEngine;

// public class PlayerRespawn : MonoBehaviour
// {
//     public Transform respawnPoint;

//     private PlayerHealth health;
//     private CharacterController controller;

//     private void Start()
//     {
//         health = GetComponent<PlayerHealth>();
//         controller = GetComponent<CharacterController>();

//         if (health != null)
//         {
//             health.OnDeath += Respawn;
//         }
//     }

//  public void Respawn()
//     {
//         Debug.Log("Respawning...");

//         if (respawnPoint == null)
//         {
//             Debug.LogError("Respawn point is missing.");
//             return;
//         }

//         if (controller != null)
//             controller.enabled = false;

//         transform.position = respawnPoint.position;
//         transform.rotation = respawnPoint.rotation;

//         if (controller != null)
//             controller.enabled = true;

//         if (health != null)
//             health.ResetHealth();

//         Animator anim = GetComponent<Animator>();
//         if (anim != null)
//         {
//             anim.Rebind();
//             anim.Update(0f);
//         }
//     }

//     public void SetRespawnPoint(Transform newPoint)
//     {
//         respawnPoint = newPoint;
//         Debug.Log("Respawn point updated to: " + newPoint.name);
//     }
// // void Respawn()
// // {
// //     Debug.Log("Respawning...");

// //     if (controller != null)
// //         controller.enabled = false;

// //     transform.position = respawnPoint.position;

// //     if (controller != null)
// //         controller.enabled = true;

// //     health.ResetHealth();

// //     // 🔥 FORCE animator to Idle
// //     Animator anim = GetComponent<Animator>();
// //     if (anim != null)
// //     {
// //         anim.Rebind();       // resets animator state
// //         anim.Update(0f);     // applies it immediately
// //     }
// // }
//     // void Respawn()
//     // {
//     //     Debug.Log("Respawning...");

//     //     if (controller != null)
//     //         controller.enabled = false;

//     //     transform.position = respawnPoint.position;

//     //     if (controller != null)
//     //         controller.enabled = true;

//     //     health.ResetHealth();
//     // }

// }