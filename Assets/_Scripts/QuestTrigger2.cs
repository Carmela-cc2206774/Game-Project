using UnityEngine;

public class SecondQuestTrigger : MonoBehaviour
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
            if (questPopupController != null)
            {
                questPopupController.ShowSecondQuestPopup();
            }

            hasTriggered = true;
        }
    }
}