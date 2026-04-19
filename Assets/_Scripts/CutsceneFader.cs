using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneFader : MonoBehaviour
{
    [SerializeField] private Image fadeOverlay;
    [SerializeField] private float fadeDuration = 0.5f;

    public IEnumerator FadeOutIn(System.Action onMiddleAction)
    {
        yield return StartCoroutine(Fade(0f, 1f));

        onMiddleAction?.Invoke();

        yield return StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float time = 0f;
        Color color = fadeOverlay.color;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = time / fadeDuration;
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            fadeOverlay.color = color;
            yield return null;
        }

        color.a = endAlpha;
        fadeOverlay.color = color;
    }
}