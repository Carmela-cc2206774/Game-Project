using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackInput : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private static readonly int Kick = Animator.StringToHash("RoundhouseKick");
    private static readonly int Bash = Animator.StringToHash("Bash");

    private bool isAttacking;

    private void Reset()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            DoKick();
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            DoBash();
        }
    }

    void DoKick()
    {
        isAttacking = true;
        animator.SetTrigger(Kick);
    }

    void DoBash()
    {
        isAttacking = true;
        animator.SetTrigger(Bash);
    }

    // Called via Animation Event at end of attack
    public void EndAttack()
    {
        isAttacking = false;
    }
}