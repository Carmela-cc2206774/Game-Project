using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ItemPickup : MonoBehaviour
{
    public GameObject pickupText;
    public string itemName = "Item"; // change per object

    private bool playerInRange = false;

    void Start()
    {
        if (pickupText != null)
        {
            pickupText.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange)
        {
            if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
            {
                PickUp();
            }
        }
    }

    void PickUp()
    {
        // if (pickupText != null)
        //     pickupText.SetActive(false);

        // Debug.Log(itemName + " picked up!");

        // Destroy(gameObject);
        StartCoroutine(PickUpWithDelay());
    }


IEnumerator PickUpWithDelay()
{
    if (pickupText != null)
        pickupText.SetActive(false);

    // 🔥 Trigger animation here
    // Example:
    // animator.SetTrigger("PickUp");

    yield return new WaitForSeconds(2f); // ⏱️ adjust delay

    Destroy(gameObject);
}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (pickupText != null)
                pickupText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (pickupText != null)
                pickupText.SetActive(false);
        }
    }
}