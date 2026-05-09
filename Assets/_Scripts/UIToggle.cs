using UnityEngine;
using TMPro;

public class UIToggle : MonoBehaviour
{
    public GameObject healthUi;
    public TMP_Text gemText;

    private void Start()
    {
        if (healthUi != null)
            healthUi.SetActive(false);

        if (gemText != null)
            gemText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (healthUi != null)
            healthUi.SetActive(true);

        if (gemText != null)
            gemText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // if (healthUi != null)
        //     healthUi.SetActive(false);

        // if (gemText != null)
        //     gemText.gameObject.SetActive(false);
    }
}