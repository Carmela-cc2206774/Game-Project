using UnityEngine;

public class LoadSelectedCharacterIntoArmature : MonoBehaviour
{
    [Header("Prefabs in same order as selection scene")]
    public GameObject[] characterPrefabs;

    [Header("Root that holds the Animator/Controller (PlayerArmature)")]
    public Animator playerAnimator;

    [Header("Where the visual model should be parented (PlayerArmature/Model)")]
    public Transform modelAnchor;

    [Header("Clean up old model under anchor")]
    public bool destroyExistingChildren = true;

    void Start()
    {
        if (playerAnimator == null)
        {
            Debug.LogError("playerAnimator not assigned.");
            return;
        }
        if (modelAnchor == null)
        {
            Debug.LogError("modelAnchor not assigned.");
            return;
        }
        if (characterPrefabs == null || characterPrefabs.Length == 0)
        {
            Debug.LogError("characterPrefabs not set.");
            return;
        }

        int selected = PlayerPrefs.GetInt("selectedCharacter", 0);
        selected = Mathf.Clamp(selected, 0, characterPrefabs.Length - 1);

        GameObject prefab = characterPrefabs[selected];
        if (prefab == null)
        {
            Debug.LogError($"Prefab at index {selected} is null.");
            return;
        }

        // Remove old visual model(s)
        if (destroyExistingChildren)
        {
            for (int i = modelAnchor.childCount - 1; i >= 0; i--)
                Destroy(modelAnchor.GetChild(i).gameObject);
        }

        // Spawn visual model
        GameObject modelInstance = Instantiate(prefab, modelAnchor);
        modelInstance.transform.localPosition = Vector3.zero;
        modelInstance.transform.localRotation = Quaternion.identity;
modelInstance.transform.localScale = Vector3.one * 100f;
        // Force visibility (in case prefab root/renderers are disabled)
        modelInstance.SetActive(true);
        foreach (Transform t in modelInstance.GetComponentsInChildren<Transform>(true))
            t.gameObject.SetActive(true);

        foreach (var r in modelInstance.GetComponentsInChildren<Renderer>(true))
            r.enabled = true;

        // Get avatar from spawned character prefab/instance
        Animator modelAnimator = modelInstance.GetComponentInChildren<Animator>(true);
        if (modelAnimator == null)
        {
            Debug.LogError("Spawned model has no Animator, cannot copy Avatar.");
            return;
        }
        if (modelAnimator.avatar == null)
        {
            Debug.LogError("Spawned model Animator has no Avatar assigned.");
            return;
        }

        // Swap the PlayerArmature avatar to the selected character avatar
        playerAnimator.avatar = modelAnimator.avatar;

        // Optional: you usually do NOT want the modelInstance Animator driving animation,
        // because PlayerArmature Animator will drive the humanoid pose.
        // Disable it to avoid conflicts.
        modelAnimator.enabled = false;

        Debug.Log($"Spawned {modelInstance.name}. Player avatar set to {playerAnimator.avatar.name}");
    }
}