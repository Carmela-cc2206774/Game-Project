using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPopupUI : MonoBehaviour
{
    public static RespawnPopupUI instance;

    [SerializeField] private GameObject popupPanel;
    [SerializeField] private string titleSceneName = "StartMenu";

    private PlayerRespawn currentPlayer;

    private void Awake()
    {
        instance = this;

        if (popupPanel != null)
            popupPanel.SetActive(false);
    }

    public void ShowPopup(PlayerRespawn player)
    {
        currentPlayer = player;

        if (popupPanel != null)
            popupPanel.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
Cursor.visible = true;
    }

    public void Continue()
    {
        Time.timeScale = 1f;

        if (popupPanel != null)
            popupPanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
Cursor.visible = false;

        if (currentPlayer != null)
            currentPlayer.Respawn();
    }

    public void ExitToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(titleSceneName);
    }
}