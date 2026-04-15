using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackInput : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMeleeDamage meleeDamage;

    [Header("Hit Timing")]
    [SerializeField] private float punchHitDelay = 0.2f;
    [SerializeField] private float crossPunchHitDelay = 0.2f;
    [SerializeField] private float kickHitDelay = 0.3f;

    [Header("Attack Lock Time")]
    [SerializeField] private float punchAttackDuration = 0.5f;
    [SerializeField] private float crossPunchAttackDuration = 0.5f;
    [SerializeField] private float kickAttackDuration = 0.7f;

    private static readonly int Kick = Animator.StringToHash("RoundhouseKick");
    private static readonly int Punch = Animator.StringToHash("Punch");
    private static readonly int CrossPunch = Animator.StringToHash("CrossPunch");
    private static readonly int PickUp = Animator.StringToHash("PickUp");

    private bool isAttacking;

    private void Reset()
    {
        animator = GetComponent<Animator>();
        meleeDamage = GetComponent<PlayerMeleeDamage>();
    }

    private void Update()
    {
        if (Keyboard.current == null) return;
        if (isAttacking) return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame || Gamepad.current.buttonNorth.wasPressedThisFrame)
        {
            StartCoroutine(DoKick()); // changed
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame || Gamepad.current.buttonWest.wasPressedThisFrame)
        {
            StartCoroutine(DoPunch());
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame || Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            StartCoroutine(DoCrossPunch());
        }
        else if (Keyboard.current.fKey.wasPressedThisFrame || Gamepad.current.leftShoulder.wasPressedThisFrame)
        {
            DoPickUp();
        }
    }

    private IEnumerator DoKick()
    {
        isAttacking = true;
        animator.SetTrigger(Kick);

        yield return new WaitForSeconds(kickHitDelay);
        meleeDamage.KickHit(); // THIS was missing

        yield return new WaitForSeconds(kickAttackDuration - kickHitDelay);
        isAttacking = false;
    }

    private IEnumerator DoPunch()
    {
        isAttacking = true;
        animator.SetTrigger(Punch);

        yield return new WaitForSeconds(punchHitDelay);
        meleeDamage.PunchHit();

        yield return new WaitForSeconds(punchAttackDuration - punchHitDelay);
        isAttacking = false;
    }

    private IEnumerator DoCrossPunch()
    {
        isAttacking = true;
        animator.SetTrigger(CrossPunch);

        yield return new WaitForSeconds(crossPunchHitDelay);
        meleeDamage.PunchHit();

        yield return new WaitForSeconds(crossPunchAttackDuration - crossPunchHitDelay);
        isAttacking = false;
    }

    private void DoPickUp()
    {
        animator.SetTrigger(PickUp);
    }
}






// using UnityEngine;
// using UnityEngine.InputSystem;

// public class PlayerAttackInput : MonoBehaviour
// {
//     [SerializeField] private Animator animator;

//     private static readonly int Kick = Animator.StringToHash("RoundhouseKick");
//     private static readonly int Punch = Animator.StringToHash("Punch");
//     private static readonly int CrossPunch = Animator.StringToHash("CrossPunch");

//  private static readonly int PickUp = Animator.StringToHash("PickUp");

//     private bool isAttacking;

//     private void Reset()
//     {
//         animator = GetComponent<Animator>();
//     }

//     private void Update()
//     {
//         if (Keyboard.current == null) return;

//         if (Keyboard.current.digit1Key.wasPressedThisFrame)
//         {
//             DoKick();
//         }

//         if (Keyboard.current.digit2Key.wasPressedThisFrame)
//         {
//             DoPunch();
//         }

//           if (Keyboard.current.digit3Key.wasPressedThisFrame)
//         {
//             DoCrossPunch();
//         }

//         if (Keyboard.current.fKey.wasPressedThisFrame)
//         {
//             DoPickUp();
//         }
//     }

//     void DoKick()
//     {
//         isAttacking = true;
//         animator.SetTrigger(Kick);
//     }

//     void DoPunch()
//     {
//         isAttacking = true;
//         animator.SetTrigger(Punch);
//     }

//      void DoCrossPunch()
//     {
//         isAttacking = true;
//         animator.SetTrigger(CrossPunch);
//     }

    
//     void DoPickUp()
//     {
//         //isAttacking = true;
//         animator.SetTrigger(PickUp);
//     }


//     // Called via Animation Event at end of attack
//     public void EndAttack()
//     {
//         isAttacking = false;
//     }
// }