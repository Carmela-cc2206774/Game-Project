using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    //[SerializeField] private string nextSceneName = "Prologue";

    private void OnEnable()
    {
        var root = uiDocument.rootVisualElement;

        Button returnButton = root.Q<Button>("return-button");
        Button exitButton = root.Q<Button>("exit-button");

        if (returnButton != null)
            returnButton.clicked += ReturnToTitle;

        if (exitButton != null)
            exitButton.clicked += ExitGame;
    }

    private void ReturnToTitle()
    {
        SceneManager.LoadScene("StartMenu");
    }

    private void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}