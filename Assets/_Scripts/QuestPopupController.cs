using UnityEngine;
using StarterAssets;
using System.Collections;

public class QuestPopupController : MonoBehaviour
{
    [Header("Quest Popups")]
    [SerializeField] private GameObject firstQuestPopup;
    [SerializeField] private GameObject secondQuestPopup;

    [Header("Second Popup Auto Close")]
    [SerializeField] private float secondPopupCloseDelay = 5f;

    [Header("Player Input")]
    [SerializeField] private StarterAssetsInputs starterInputs;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip popupSound;

    private bool firstQuestCompleted = false;
    private bool popupIsOpen = false;

    private void Start()
    {
        if (firstQuestPopup != null)
            firstQuestPopup.SetActive(false);

        if (secondQuestPopup != null)
            secondQuestPopup.SetActive(false);
    }

    private void Update()
    {
        if (popupIsOpen)
            UnlockCursor();
    }

    private void LateUpdate()
    {
        if (popupIsOpen)
            UnlockCursor();
    }

    public void ShowQuestPopup()
    {
        ShowFirstQuestPopup();
    }

    public void HideQuestPopup()
    {
        HideFirstQuestPopup();
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

        StartCoroutine(AutoCloseSecondPopup());
    }

    public void HideSecondQuestPopup()
    {
        HidePopup(secondQuestPopup);
    }

    private IEnumerator AutoCloseSecondPopup()
    {
        yield return new WaitForSecondsRealtime(secondPopupCloseDelay);

        HideSecondQuestPopup();
    }

    private void ShowPopup(GameObject popup)
    {
        if (popup != null)
            popup.SetActive(true);

        if (audioSource != null && popupSound != null)
            audioSource.PlayOneShot(popupSound);

        Time.timeScale = 0f;
        popupIsOpen = true;

        UnlockCursor();
    }

    private void HidePopup(GameObject popup)
    {
        if (popup != null)
            popup.SetActive(false);

        Time.timeScale = 1f;
        popupIsOpen = false;

        LockCursor();
    }

    private void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (starterInputs != null)
        {
            starterInputs.cursorLocked = false;
            starterInputs.cursorInputForLook = false;
        }
    }

    private void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (starterInputs != null)
        {
            starterInputs.cursorLocked = true;
            starterInputs.cursorInputForLook = true;
        }
    }
    public void ShowSecondQuestPopup()
    {
        ShowPopup(secondQuestPopup);
        StartCoroutine(AutoCloseSecondPopup());
    }
}