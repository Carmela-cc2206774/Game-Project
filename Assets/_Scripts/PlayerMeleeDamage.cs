using UnityEngine;

public class PlayerMeleeDamage : MonoBehaviour
{
    [Header("Attack Points")]
    public Transform punchPoint;
    public Transform kickPoint;

    [Header("Attack Settings")]
    public float punchRange = 1f;
    public float kickRange = 1.2f;

    public int punchDamage = 10;
    public int kickDamage = 15;

    public LayerMask enemyLayers;

    private void Start()
    {
        if (punchPoint == null)
        {
            punchPoint = FindChildByName(transform, "PunchPoint");
            Debug.Log("Punch point found: " + (punchPoint != null ? punchPoint.name : "NULL"));
        }

        if (kickPoint == null)
        {
            kickPoint = FindChildByName(transform, "KickPoint");
            Debug.Log("Kick point found: " + (kickPoint != null ? kickPoint.name : "NULL"));
        }
    }

    public void PunchHit()
    {
        if (punchPoint == null)
        {
            punchPoint = FindChildByName(transform, "PunchPoint");
        }

        if (punchPoint == null)
        {
            Debug.LogWarning("PunchPoint not assigned or found.");
            return;
        }

        Collider[] hitEnemies = Physics.OverlapSphere(
            punchPoint.position,
            punchRange,
            enemyLayers
        );

        foreach (Collider enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponentInParent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(punchDamage);
            }
        }
    }

    public void KickHit()
    {
        if (kickPoint == null)
        {
            kickPoint = FindChildByName(transform, "KickPoint");
        }

        if (kickPoint == null)
        {
            Debug.LogWarning("KickPoint not assigned or found.");
            return;
        }

        Collider[] hitEnemies = Physics.OverlapSphere(
            kickPoint.position,
            kickRange,
            enemyLayers
        );

        foreach (Collider enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponentInParent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(kickDamage);
            }
        }
    }

    private Transform FindChildByName(Transform parent, string childName)
    {
        foreach (Transform child in parent.GetComponentsInChildren<Transform>(true))
        {
            if (child.name == childName)
                return child;
        }
        return null;
    }

    private void OnDrawGizmosSelected()
    {
        if (punchPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(punchPoint.position, punchRange);
        }

        if (kickPoint != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(kickPoint.position, kickRange);
        }
    }
}