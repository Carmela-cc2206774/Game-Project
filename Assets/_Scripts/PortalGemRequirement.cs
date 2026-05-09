using UnityEngine;
using TMPro;

public class PortalGemRequirement : MonoBehaviour
{
    [SerializeField] private int requiredGems = 5;

    [Header("Barrier")]
    [SerializeField] private GameObject barrier;

    [Header("Dialogue")]
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private TMP_Text messageText;

    private bool hasUnlocked = false;

    private void Start()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (hasUnlocked) return;

        int currentGems = GemManager.instance.GetGemCount();

        if (currentGems >= requiredGems)
        {
            hasUnlocked = true;

            if (barrier != null)
                barrier.SetActive(false);

            ShowMessage("The portal awakens...");
        }
        else
        {
            int remaining = requiredGems - currentGems;

            ShowMessage($"You still need {remaining} more gems.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        HideMessage();
    }

    void ShowMessage(string message)
    {
        if (messagePanel != null)
            messagePanel.SetActive(true);

        if (messageText != null)
            messageText.text = message;
    }

    void HideMessage()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false);
    }
}