using UnityEngine;
using UnityEngine.InputSystem;

public class ActionsManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private static readonly int PickUp = Animator.StringToHash("PickUp");

    //private bool isAttacking;

    private void Reset()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            DoPickUp();
        }

       
    }

    void DoPickUp()
    {
        //isAttacking = true;
        animator.SetTrigger(PickUp);
    }

    // Called via Animation Event at end of attack
    // public void EndAttack()
    // {
    //     isAttacking = false;
    // }
}