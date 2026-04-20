using System.Collections;
using UnityEngine;
using TMPro;
using HisaGames.CutsceneManager;

public class NPCInteractTrigger : MonoBehaviour
{
    [Header("NPC")]
    [SerializeField] private Animator npcAnimator;
    [SerializeField] private string waveTriggerName = "Wave";

    [Header("UI Prompt")]
    [SerializeField] private GameObject talkPromptObject;
    [SerializeField] private TMP_Text talkPromptText;
    [SerializeField] private string promptMessage = "Talk to Her [E]";

    [Header("Cameras")]
    [SerializeField] private Camera gameplayCamera;
    [SerializeField] private Camera talkCamera;
    [SerializeField] private float cameraZoomDelay = 0.8f;

    [Header("Dialogue")]
    [SerializeField] private string cutsceneName;

    [Header("Player")]
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private MonoBehaviour playerMovementScript;
    [SerializeField] private MonoBehaviour playerLookScript;

    private bool playerInside = false;
    private bool hasInteracted = false;
    private bool isStartingConversation = false;

    private void Start()
    {
        if (talkPromptObject != null)
            talkPromptObject.SetActive(false);

        if (talkCamera != null)
            talkCamera.gameObject.SetActive(false);

        if (gameplayCamera != null)
            gameplayCamera.gameObject.SetActive(true);

        if (talkPromptText != null)
            talkPromptText.text = promptMessage;
    }

    private void Update()
    {
        if (!playerInside || hasInteracted || isStartingConversation)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(StartConversationRoutine());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag))
            return;

        playerInside = true;

        if (npcAnimator != null && !string.IsNullOrEmpty(waveTriggerName))
            npcAnimator.SetTrigger(waveTriggerName);

        if (talkPromptObject != null)
            talkPromptObject.SetActive(true);

        if (talkPromptText != null)
            talkPromptText.text = promptMessage;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag))
            return;

        playerInside = false;

        if (!hasInteracted && talkPromptObject != null)
            talkPromptObject.SetActive(false);
    }

    private IEnumerator StartConversationRoutine()
    {
        isStartingConversation = true;
        hasInteracted = true;

        if (talkPromptObject != null)
            talkPromptObject.SetActive(false);

        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        if (playerLookScript != null)
            playerLookScript.enabled = false;

        if (gameplayCamera != null)
            gameplayCamera.gameObject.SetActive(false);

        if (talkCamera != null)
            talkCamera.gameObject.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        yield return new WaitForSeconds(cameraZoomDelay);

        if (EcCutsceneManager.instance != null && !string.IsNullOrEmpty(cutsceneName))
        {
            EcCutsceneManager.instance.InitCutscenes(cutsceneName);
        }
        else
        {
            Debug.LogWarning("NPCInteractTrigger: CutsceneManager instance or cutsceneName is missing.");
        }

        isStartingConversation = false;
    }

    public void EndConversation()
    {
        if (talkCamera != null)
            talkCamera.gameObject.SetActive(false);

        if (gameplayCamera != null)
            gameplayCamera.gameObject.SetActive(true);

        if (playerMovementScript != null)
            playerMovementScript.enabled = true;

        if (playerLookScript != null)
            playerLookScript.enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}