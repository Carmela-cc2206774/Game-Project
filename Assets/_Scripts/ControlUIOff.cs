using UnityEngine;
using TMPro;

public class ControlUIOff : MonoBehaviour
{
    public GameObject ctUI;
    //public TMP_Text gemText;

    private void Start()
    {
        // if (ctUI != null)
        //     ctUI.SetActive(false);

        // if (gemText != null)
        //     gemText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (ctUI != null)
            ctUI.SetActive(false);

        // if (gemText != null)
        //     gemText.gameObject.SetActive(true);
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