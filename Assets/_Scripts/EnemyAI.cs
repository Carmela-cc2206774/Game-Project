using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private Rigidbody rb;

    [Header("Movement")]
    public float speed = 3f;
    public float chaseRange = 10f;
    public float attackRange = 1.5f;

    [Header("Attack")]
    public float attackCooldown = 1.5f;
    public int damage = 10;
    public Transform attackPoint;
    public LayerMask playerLayer;

    [Header("Animation")]
    public Animator animator;

    private float lastAttackTime;
    private bool isTakingHit = false;
    private bool isDead = false;

    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player == null || isTakingHit || isDead)
        {
            StopMoving();
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseRange && distance > attackRange)
        {
            ChasePlayer();
        }
        else if (distance <= attackRange)
        {
            StopChasing();
            TryAttack();
        }
        else
        {
            StopChasing();
        }
    }

    void ChasePlayer()
    {
        if (animator != null)
            animator.SetBool(Run, true);

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;
        direction.Normalize();

        if (rb != null)
        {
            Vector3 velocity = direction * speed;
            rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
        }
        else
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        Vector3 lookPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookPos);
    }

    void StopChasing()
    {
        if (animator != null)
            animator.SetBool(Run, false);

        StopMoving();
    }

    void StopMoving()
    {
        if (rb != null)
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        }
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime < attackCooldown) return;

        lastAttackTime = Time.time;

        if (animator != null)
        {
            animator.SetBool(Run, false);
            animator.SetTrigger(Attack);
        }

        DoDamage();
    }

    public void DoDamage()
    {
        if (attackPoint == null)
        {
            Debug.LogWarning("Enemy attackPoint is missing.");
            return;
        }

        Collider[] hits = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

        foreach (Collider hit in hits)
        {
            PlayerHealth playerHealth = hit.GetComponentInParent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Enemy damaged player.");
            }
        }
    }

    public void StartTakingHit(float stunTime)
    {
        StartCoroutine(TakeHitRoutine(stunTime));
    }

    IEnumerator TakeHitRoutine(float stunTime)
    {
        isTakingHit = true;
        StopChasing();

        yield return new WaitForSeconds(stunTime);

        isTakingHit = false;
    }

    public void SetDead()
    {
        isDead = true;
        StopChasing();
        enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}