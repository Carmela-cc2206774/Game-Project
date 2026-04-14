using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] private QuestPopupController questPopupController;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private bool triggerOnlyOnce = true;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered && triggerOnlyOnce) return;

        if (other.CompareTag(playerTag))
        {
            questPopupController.ShowQuestPopup();
            hasTriggered = true;
        }
    }
}