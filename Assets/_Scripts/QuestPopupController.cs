// using UnityEngine;
// using UnityEngine.InputSystem;

// public class QuestPopupController : MonoBehaviour
// {
//     [SerializeField] private GameObject questPopup;
//     [SerializeField] private AudioSource audioSource;
//     [SerializeField] private AudioClip popupSound;

//     public void ShowQuestPopup()
//     {
//         if (questPopup != null)
//             questPopup.SetActive(true);

//         if (audioSource != null && popupSound != null)
//             audioSource.PlayOneShot(popupSound);

//         Time.timeScale = 0f;

//         Cursor.visible = true;
//         Cursor.lockState = CursorLockMode.None;
//     }

//     public void HideQuestPopup()
//     {
//         if (questPopup != null)
//             questPopup.SetActive(false);

//         Time.timeScale = 1f;

//         Cursor.visible = false;
//         Cursor.lockState = CursorLockMode.Locked;
//     }
// }

using UnityEngine;

public class QuestPopupController : MonoBehaviour
{
    [Header("Quest Popups")]
    [SerializeField] private GameObject firstQuestPopup;
    [SerializeField] private GameObject secondQuestPopup;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip popupSound;

    private bool firstQuestCompleted = false;

    private void Start()
    {
        if (firstQuestPopup != null)
            firstQuestPopup.SetActive(false);

        if (secondQuestPopup != null)
            secondQuestPopup.SetActive(false);
    }

    public void ShowFirstQuestPopup()
    {
        ShowPopup(firstQuestPopup);
    }

    public void HideFirstQuestPopup()
    {
        HidePopup(firstQuestPopup);
    }

    public void CompleteFirstQuest()
    {
        if (firstQuestCompleted) return;

        firstQuestCompleted = true;

        if (firstQuestPopup != null)
            firstQuestPopup.SetActive(false);

        ShowPopup(secondQuestPopup);
    }

    public void HideSecondQuestPopup()
    {
        HidePopup(secondQuestPopup);
    }

    private void ShowPopup(GameObject popup)
    {
        if (popup != null)
            popup.SetActive(true);

        if (audioSource != null && popupSound != null)
            audioSource.PlayOneShot(popupSound);

        Time.timeScale = 0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void HidePopup(GameObject popup)
    {
        if (popup != null)
            popup.SetActive(false);

        Time.timeScale = 1f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}