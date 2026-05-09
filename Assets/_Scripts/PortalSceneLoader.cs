using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PortalSceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "EndMenu";

    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private AudioClip portalSound;

    [Header("Objects To Hide")]
    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;
    [SerializeField] private GameObject object3;
    [SerializeField] private TMP_Text textToHide;

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

        // Hide objects/text
        if (object1 != null)
            object1.SetActive(false);

        if (object2 != null)
            object2.SetActive(false);
            
        if (object3 != null)
            object3.SetActive(false);

        if (textToHide != null)
            textToHide.gameObject.SetActive(false);

        // Show loading panel
        if (loadingPanel != null)
            loadingPanel.SetActive(true);

        // Play portal sound
        if (portalSound != null)
        {
            AudioSource.PlayClipAtPoint(portalSound, transform.position);
        }

        yield return new WaitForSeconds(3f);

        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}

// using System.Collections;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PortalSceneLoader : MonoBehaviour
// {
//     [SerializeField] private string sceneToLoad = "EndMenu";
//     [SerializeField] private GameObject loadingPanel;
//     [SerializeField] private AudioClip portalSound;

//     private bool isLoading = false;

//     private void Start()
//     {
//         if (loadingPanel != null)
//             loadingPanel.SetActive(false);
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (!other.CompareTag("Player")) return;
//         if (isLoading) return;

//         StartCoroutine(LoadSceneRoutine());
//     }

//     private IEnumerator LoadSceneRoutine()
// {
//     isLoading = true;

//     if (loadingPanel != null)
//         loadingPanel.SetActive(true);

//     if (portalSound != null)
//     {
//         AudioSource.PlayClipAtPoint(portalSound, transform.position);
//     }

//     // lets loading image appear
//     yield return new WaitForSeconds(3f);

//     SceneManager.LoadSceneAsync(sceneToLoad);
// }
// }

// // using UnityEngine;
// // using UnityEngine.SceneManagement;

// // public class PortalSceneLoader : MonoBehaviour
// // {
// //     [SerializeField] private string sceneToLoad = "EndMenu";

// //     private void OnTriggerEnter(Collider other)
// //     {
// //         if (!other.CompareTag("Player")) return;

// //         SceneManager.LoadScene(sceneToLoad);
// //     }
// // }