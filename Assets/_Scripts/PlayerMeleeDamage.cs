using UnityEngine;

public class PlayerMeleeDamage : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 1.2f;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private int punchDamage = 20;
    [SerializeField] private int kickDamage = 30;

    public void DoPunchDamage()
    {
        DealDamage(punchDamage);
    }

    public void DoKickDamage()
    {
        DealDamage(kickDamage);
    }

    private void DealDamage(int damage)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}