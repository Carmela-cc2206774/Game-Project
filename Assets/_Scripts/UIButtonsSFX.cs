using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUISFX : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private AudioSource uiAudioSource;

    [Header("Clips")]
    [SerializeField] private AudioClip hoverClip;
    [SerializeField] private AudioClip clickClip;

    private Button startButton;
    private Button settingsButton;
    private Button exitButton;

    private void OnEnable()
    {
        if (uiDocument == null)
            uiDocument = GetComponent<UIDocument>();

        if (uiDocument == null || uiAudioSource == null)
        {
            Debug.LogWarning("UIDocument or AudioSource is missing.");
            return;
        }

        var root = uiDocument.rootVisualElement;

        startButton = root.Q<Button>("start-button");
        settingsButton = root.Q<Button>("settings-button");
        exitButton = root.Q<Button>("exit-button");

        RegisterButtonEvents(startButton);
        RegisterButtonEvents(settingsButton);
        RegisterButtonEvents(exitButton);
    }

    private void OnDisable()
    {
        UnregisterButtonEvents(startButton);
        UnregisterButtonEvents(settingsButton);
        UnregisterButtonEvents(exitButton);
    }

    private void RegisterButtonEvents(Button button)
    {
        if (button == null) return;

        button.RegisterCallback<MouseEnterEvent>(OnButtonHover);
        button.clicked += OnButtonClick;
    }

    private void UnregisterButtonEvents(Button button)
    {
        if (button == null) return;

        button.UnregisterCallback<MouseEnterEvent>(OnButtonHover);
        button.clicked -= OnButtonClick;
    }

    private void OnButtonHover(MouseEnterEvent evt)
    {
        if (hoverClip != null)
            uiAudioSource.PlayOneShot(hoverClip);
    }

    private void OnButtonClick()
    {
        if (clickClip != null)
            uiAudioSource.PlayOneShot(clickClip);
    }
}