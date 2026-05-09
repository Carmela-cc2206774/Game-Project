using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalSceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "EndMenu";
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private AudioClip portalSound;

    private bool isLoading = false;

    private void Start()
    {
        if (loadingPanel != null)
            loadingPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (isLoading) return;

        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
{
    isLoading = true;

    if (loadingPanel != null)
        loadingPanel.SetActive(true);

    if (portalSound != null)
    {
        AudioSource.PlayClipAtPoint(portalSound, transform.position);
    }

    // lets loading image appear
    yield return new WaitForSeconds(2f);

    SceneManager.LoadSceneAsync(sceneToLoad);
}
}

// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PortalSceneLoader : MonoBehaviour
// {
//     [SerializeField] private string sceneToLoad = "EndMenu";

//     private void OnTriggerEnter(Collider other)
//     {
//         if (!other.CompareTag("Player")) return;

//         SceneManager.LoadScene(sceneToLoad);
//     }
// }