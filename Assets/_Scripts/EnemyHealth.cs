using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    [Header("Drop")]
public GameObject gemPrefab;
public Transform dropPoint;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    [Header("Health Bar")]
    [SerializeField] private Image healthBarFill;

    private static readonly int TakePunch = Animator.StringToHash("TakePunch");
    private static readonly int Death = Animator.StringToHash("Death");

    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        UpdateHealthBar();
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return;

        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(gameObject.name + " took damage. Health left: " + currentHealth);

        UpdateHealthBar();

        if (currentHealth > 0)
        {
            animator.SetTrigger(TakePunch);
            EnemyAI enemyAI = GetComponent<EnemyAI>();
    if (enemyAI != null)
    {
        enemyAI.StartTakingHit(0.6f);
    }
        }
        else
        {
  
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log(gameObject.name + " died.");

        animator.SetTrigger(Death);
        EnemyAI enemyAI = GetComponent<EnemyAI>();
if (enemyAI != null)
{
    enemyAI.SetDead();
}
if (gemPrefab != null)
{
    Vector3 dropPosition = dropPoint != null 
        ? dropPoint.position 
        : transform.position + Vector3.up * 0.5f;

    Instantiate(gemPrefab, dropPosition, Quaternion.identity);
}
        Destroy(gameObject, 2f);
    }
}

// using UnityEngine;

// public class EnemyHealth : MonoBehaviour
// {
//     public int maxHealth = 30;
//     private int currentHealth;

//     private void Start()
//     {
//         currentHealth = maxHealth;
//     }

//     public void TakeDamage(int damageAmount)
//     {
//         currentHealth -= damageAmount;
//         Debug.Log(gameObject.name + " took damage. Health left: " + currentHealth);

//         if (currentHealth <= 0)
//         {
//             Die();
//         }
//     }

//     private void Die()
//     {
//         Debug.Log(gameObject.name + " died.");
//         Destroy(gameObject);
//     }
// }