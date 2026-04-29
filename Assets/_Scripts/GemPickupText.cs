using UnityEngine;
using TMPro;

public class GemPickupText : MonoBehaviour
{
    public static GemPickupText instance;

    public GameObject pickupTextObject;
    public TMP_Text pickupText;

    private void Awake()
    {
        instance = this;
        pickupTextObject.SetActive(false);
    }

    public void ShowPickup(string text)
    {
        pickupTextObject.SetActive(true);
        pickupText.text = text;
    }

    public void HidePickup()
    {
        pickupTextObject.SetActive(false);
    }
}