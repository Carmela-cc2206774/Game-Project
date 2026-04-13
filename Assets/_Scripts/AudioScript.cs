using System.Collections;
using UnityEngine;

public class AudioFader : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float defaultFadeTime = 1f;

    private Coroutine fadeCoroutine;

    public void FadeOut()
    {
        FadeTo(0f, defaultFadeTime);
    }

    public void FadeIn()
    {
        FadeTo(1f, defaultFadeTime);
    }

    public void FadeToHalf()
    {
        FadeTo(0.5f, defaultFadeTime);
    }

    public void FadeTo(float targetVolume, float duration)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeRoutine(targetVolume, duration));
    }

    private IEnumerator FadeRoutine(float targetVolume, float duration)
    {
        float startVolume = audioSource.volume;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }
}