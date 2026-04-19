using UnityEngine;
using UnityEngine.InputSystem;

public class UISound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (audioSource != null && clickSound != null)
                audioSource.PlayOneShot(clickSound);
        }
    }
}