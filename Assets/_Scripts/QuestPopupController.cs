using UnityEngine;
using UnityEngine.InputSystem;

public class QuestPopupController : MonoBehaviour
{
    [SerializeField] private GameObject questPopup;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip popupSound;

    public void ShowQuestPopup()
    {
        if (questPopup != null)
            questPopup.SetActive(true);

        if (audioSource != null && popupSound != null)
            audioSource.PlayOneShot(popupSound);

        Time.timeScale = 0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideQuestPopup()
    {
        if (questPopup != null)
            questPopup.SetActive(false);

        Time.timeScale = 1f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}