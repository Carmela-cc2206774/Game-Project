using TMPro;
using UnityEngine;

public class GemManager : MonoBehaviour
{
    public static GemManager instance;

    public int gemCount = 0;
    public TMP_Text gemText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddGem()
    {
        gemCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (gemText != null)
            gemText.text = "Gems: " + gemCount;
    }
}