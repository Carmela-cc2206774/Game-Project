using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class ObstacleCourseTrigger : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject buttonObject;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private string promptMessage = "Enter Obstacle Course [E]";
    [SerializeField] private float promptFontSize = 36f;

    [Header("Player")]
    [SerializeField] private string playerTag = "Player";

    [Header("Scene")]
    [SerializeField] private string obstacleCourseSceneName = "ObstacleCourse";

    private bool playerInside = false;

    private void Start()
    {
        if (buttonObject != null)
            buttonObject.SetActive(false);

        UpdatePromptVisuals();
    }

    private void Update()
    {
        if (!playerInside) return;

        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            LoadObstacleCourse();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        playerInside = true;

        UpdatePromptVisuals();

        if (buttonObject != null)
            buttonObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        playerInside = false;

        if (buttonObject != null)
            buttonObject.SetActive(false);
    }

    private void UpdatePromptVisuals()
    {
        if (buttonText == null) return;

        buttonText.text = promptMessage;
        buttonText.fontSize = promptFontSize;
    }

    private void LoadObstacleCourse()
    {
        SceneManager.LoadScene(obstacleCourseSceneName);
    }
}