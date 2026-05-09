using UnityEngine;
using UnityEngine.InputSystem;

public class GemPickup : MonoBehaviour
{
    private bool playerInRange = false;
    public AudioClip pickupSound;

    void Update()
    {
        if (!playerInRange) return;

        if (Keyboard.current != null &&
            Keyboard.current.fKey.wasPressedThisFrame)
        {
            Debug.Log("Pressed F near gem");

            if (GemManager.instance != null)
                GemManager.instance.AddGem();
            else
                Debug.LogError("GemManager instance is missing.");

            if (pickupSound != null)
                 AudioSource.PlayClipAtPoint(pickupSound, transform.position);
                 
            GemPickupText.instance?.HidePickup();
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Gem trigger entered by: " + other.name);

        if (other.CompareTag("Player") ||
            other.GetComponentInParent<PlayerHealth>() != null)
        {
            playerInRange = true;

            GemPickupText.instance?.ShowPickup("Press F to pick up gem");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") ||
            other.GetComponentInParent<PlayerHealth>() != null)
        {
            playerInRange = false;

            GemPickupText.instance?.HidePickup();
        }
    }
}
// using UnityEngine;
// using UnityEngine.InputSystem;

// public class GemPickup : MonoBehaviour
// {
//    // public GameObject pickupText;

//     private bool playerInRange = false;

//     void Update()
//     {
//         if (!playerInRange) return;

//         if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
//         {
//             Debug.Log("Pressed F near gem");

//             if (GemManager.instance != null)
//                 GemManager.instance.AddGem();
//             else
//                 Debug.LogError("GemManager instance is missing.");

//             if (pickupText != null)
//                 pickupText.SetActive(false);

//             Destroy(gameObject);
//         }
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         Debug.Log("Gem trigger entered by: " + other.name);

//         if (other.CompareTag("Player") || other.GetComponentInParent<PlayerHealth>() != null)
//         {
//             playerInRange = true;

//             if (pickupText != null)
//                 pickupText.SetActive(true);
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Player") || other.GetComponentInParent<PlayerHealth>() != null)
//         {
//             playerInRange = false;

//             if (pickupText != null)
//                 pickupText.SetActive(false);
//         }
//     }
// }