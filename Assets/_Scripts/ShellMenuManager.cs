using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UIDocument))]
public class ShellMenuUI : MonoBehaviour
{

    [SerializeField] private string ClosetSceneName = "MapScene";
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    private UIDocument uiDocument;

    private VisualElement root;
    private VisualElement dimBackground;
    private VisualElement shellContainer;

    private Button menuOpenButton;
    private Button closeButton;
    private Button mapButton;
    private Button saveButton;
    private Button exitButton;

    private bool isOpen;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
    }

    private void Start()
    {
        if (uiDocument == null)
        {
            Debug.LogError("ShellMenuUI: UIDocument is not assigned.");
            return;
        }

        root = uiDocument.rootVisualElement;

        dimBackground = root.Q<VisualElement>("dim-background");
        shellContainer = root.Q<VisualElement>("shell-container");

        menuOpenButton = root.Q<Button>("menu-open-button");
        closeButton = root.Q<Button>("close-button");
        mapButton = root.Q<Button>("map-button");
        saveButton = root.Q<Button>("save-button");
        exitButton = root.Q<Button>("exit-button");

        ShowClosedState();

        if (menuOpenButton != null)
            menuOpenButton.clicked += OpenMenu;

        if (closeButton != null)
            closeButton.clicked += CloseMenu;

        if (mapButton != null)
            mapButton.clicked += OnMapClicked;

        if (saveButton != null)
            saveButton.clicked += OnSaveClicked;

        if (exitButton != null)
            exitButton.clicked += OnExitClicked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        if (isOpen)
            CloseMenu();
        else
            OpenMenu();
    }

    private void OpenMenu()
    {
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;

        isOpen = true;

        if (menuOpenButton != null)
            menuOpenButton.style.display = DisplayStyle.None;

        if (dimBackground != null)
            dimBackground.style.display = DisplayStyle.Flex;

        if (shellContainer != null)
            shellContainer.style.display = DisplayStyle.Flex;


    }

    private void CloseMenu()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        isOpen = false;
        ShowClosedState();
    }

    private void ShowClosedState()
    {
        if (menuOpenButton != null)
            menuOpenButton.style.display = DisplayStyle.Flex;

        if (dimBackground != null)
            dimBackground.style.display = DisplayStyle.None;

        if (shellContainer != null)
            shellContainer.style.display = DisplayStyle.None;
    }

    private void OnMapClicked()
    {
        Debug.Log("Closet clicked");
        Time.timeScale = 2f;
        SceneManager.LoadScene(ClosetSceneName);
    }

    private void OnSaveClicked()
    {
        Debug.Log("Save clicked");
    }

    private void OnExitClicked()
    {
        Time.timeScale = 2f;
        SceneManager.LoadScene(mainMenuSceneName);
    }
}