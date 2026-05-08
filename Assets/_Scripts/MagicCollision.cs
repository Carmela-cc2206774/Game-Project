// using UnityEngine;

// public class MagicCollision : MonoBehaviour
// {
//     public int damage = 10;
//     public bool destroyOnHit = true;

//     private void OnCollisionEnter(Collision collision)
//     {
//         HandleHit(collision.collider);
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         HandleHit(other);
//     }

//     void HandleHit(Collider col)
//     {
//         // Try damage
//         EnemyHealth enemyHealth = col.GetComponentInParent<EnemyHealth>();

//         if (enemyHealth != null)
//         {
//             enemyHealth.TakeDamage(damage);
//         }

//         // Always destroy on any hit (enemy, terrain, wall, etc)
//         if (destroyOnHit)
//         {
//             Destroy(gameObject);
//         }
//     }
// }
using UnityEngine;

public class MagicCollision : MonoBehaviour
{
    public int damage = 10;
    public bool destroyOnHit = true;

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemyHealth = collision.collider.GetComponentInParent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }

        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponentInParent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);

            if (destroyOnHit)
            {
                Destroy(gameObject);
            }
        }
    }
}