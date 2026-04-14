using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackInput : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private static readonly int Kick = Animator.StringToHash("RoundhouseKick");
    private static readonly int Punch = Animator.StringToHash("Punch");
    private static readonly int CrossPunch = Animator.StringToHash("CrossPunch");

 private static readonly int PickUp = Animator.StringToHash("PickUp");

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
            DoPunch();
        }

          if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            DoCrossPunch();
        }

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            DoPickUp();
        }
    }

    void DoKick()
    {
        isAttacking = true;
        animator.SetTrigger(Kick);
    }

    void DoPunch()
    {
        isAttacking = true;
        animator.SetTrigger(Punch);
    }

     void DoCrossPunch()
    {
        isAttacking = true;
        animator.SetTrigger(CrossPunch);
    }

    
    void DoPickUp()
    {
        //isAttacking = true;
        animator.SetTrigger(PickUp);
    }


    // Called via Animation Event at end of attack
    public void EndAttack()
    {
        isAttacking = false;
    }
}