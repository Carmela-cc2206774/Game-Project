using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class ObstacleCourseTrigger : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject buttonObject;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private string promptMessage = "Enter Obstacle Course [E]";
    [SerializeField] private float promptFontSize = 36f;

 [Header("Loading")]
    [SerializeField] private GameObject loadingPanel;

    [Header("Player")]
    [SerializeField] private string playerTag = "Player";

    [Header("Scene")]
    [SerializeField] private string obstacleCourseSceneName = "ObstacleCourse";

    private bool playerInside = false;
     private bool isLoading = false;

    private void Start()
    {
        if (buttonObject != null)
            buttonObject.SetActive(false);

        if (loadingPanel != null)
            loadingPanel.SetActive(false);

        UpdatePromptVisuals();
    }

    private void Update()
    {
        if (!playerInside || isLoading) return;

        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            StartCoroutine(LoadObstacleCourseRoutine());//LoadObstacleCourse();
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

    // private void LoadObstacleCourse()
    // {
    //     SceneManager.LoadScene(obstacleCourseSceneName);
    // }

    private IEnumerator LoadObstacleCourseRoutine()
    {
        isLoading = true;

        if (buttonObject != null)
            buttonObject.SetActive(false);

        if (loadingPanel != null)
            loadingPanel.SetActive(true);

        yield return null;

        SceneManager.LoadSceneAsync(obstacleCourseSceneName);
    }
}