using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private bool preventDoubleLoad = true;

    private bool isLoading = false;

    public void LoadSceneSafely(string sceneName)
    {
        if (isLoading && preventDoubleLoad)
        {
            Debug.LogWarning("A scene is already loading.");
            return;
        }

        if (string.IsNullOrWhiteSpace(sceneName))
        {
            Debug.LogError("Scene name is empty.");
            return;
        }

        if (!Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogError($"Scene '{sceneName}' is not in Build Settings or could not be found.");
            return;
        }

        isLoading = true;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneSafely(int sceneIndex)
    {
        if (isLoading && preventDoubleLoad)
        {
            Debug.LogWarning("A scene is already loading.");
            return;
        }

        if (sceneIndex < 0 || sceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError($"Scene index {sceneIndex} is out of range.");
            return;
        }

        isLoading = true;
        SceneManager.LoadScene(sceneIndex);
    }
}