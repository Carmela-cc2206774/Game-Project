using UnityEngine;
using UnityEngine.InputSystem;

public class GemPickup : MonoBehaviour
{
    public GameObject pickupText;

    private bool playerInRange = false;

    void Update()
    {
        if (!playerInRange) return;

        if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
        {
            Debug.Log("Pressed F near gem");

            if (GemManager.instance != null)
                GemManager.instance.AddGem();
            else
                Debug.LogError("GemManager instance is missing.");

            if (pickupText != null)
                pickupText.SetActive(false);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Gem trigger entered by: " + other.name);

        if (other.CompareTag("Player") || other.GetComponentInParent<PlayerHealth>() != null)
        {
            playerInRange = true;

            if (pickupText != null)
                pickupText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponentInParent<PlayerHealth>() != null)
        {
            playerInRange = false;

            if (pickupText != null)
                pickupText.SetActive(false);
        }
    }
}