using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ItemPickup : MonoBehaviour
{
    [Header("Pickup Settings")]
    public GameObject pickupText;
    public string itemName = "Item";

    [Header("Quest Settings")]
    [SerializeField] private QuestPopupController questPopupController;
    [SerializeField] private int requiredItems = 2;

    private static int pickedUpCount = 0;
    private static bool nextQuestTriggered = false;

    private bool playerInRange = false;
    private bool isPickedUp = false;

    void Start()
    {
        if (pickupText != null)
        {
            pickupText.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && !isPickedUp)
        {
            if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
            {
                PickUp();
            }
        }
    }

    void PickUp()
    {
        if (isPickedUp) return;

        isPickedUp = true;
        StartCoroutine(PickUpWithDelay());
    }

    IEnumerator PickUpWithDelay()
    {
        if (pickupText != null)
            pickupText.SetActive(false);

        Debug.Log(itemName + " picked up!");

        yield return new WaitForSeconds(2f);

        pickedUpCount++;

        Debug.Log("Quest items picked up: " + pickedUpCount + "/" + requiredItems);

        if (pickedUpCount >= requiredItems && !nextQuestTriggered)
        {
            nextQuestTriggered = true;

            if (questPopupController != null)
            {
                questPopupController.CompleteFirstQuest();
            }
            else
            {
                Debug.LogWarning("QuestPopupController is not assigned on " + gameObject.name);
            }
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
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