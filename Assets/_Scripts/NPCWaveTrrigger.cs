using UnityEngine;

public class NPCWaveTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private static readonly int Wave = Animator.StringToHash("Wave");

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered NPC range");
            animator.SetTrigger(Wave);
        }
    }
}