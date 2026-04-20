using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private Image fadeOverlay;
    [SerializeField] private float fadeDuration = 2f;

    private void Start()
    {
        if (fadeOverlay == null) return;

        // Make sure overlay starts black
        fadeOverlay.gameObject.SetActive(true);

        Color c = fadeOverlay.color;
        c.a = 1f;
        fadeOverlay.color = c;

        StartCoroutine(FadeFromBlack());
    }

    private IEnumerator FadeFromBlack()
    {
        float time = 0f;
        Color c = fadeOverlay.color;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, time / fadeDuration);
            fadeOverlay.color = c;
            yield return null;
        }

        c.a = 0f;
        fadeOverlay.color = c;
        fadeOverlay.gameObject.SetActive(false);
    }
}