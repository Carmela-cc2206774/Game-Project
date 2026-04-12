using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private string nextSceneName = "Prologue";

    private void OnEnable()
    {
        var root = uiDocument.rootVisualElement;

        Button startButton = root.Q<Button>("start-button");
        Button exitButton = root.Q<Button>("exit-button");

        if (startButton != null)
            startButton.clicked += StartGame;

        if (exitButton != null)
            exitButton.clicked += ExitGame;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    private void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}