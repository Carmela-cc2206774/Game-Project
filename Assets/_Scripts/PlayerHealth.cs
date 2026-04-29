using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBarFill;
    public int maxHealth = 100;
    public int currentHealth;

    public Animator animator;
    public System.Action OnDeath;

    private bool isDead = false;

    private static readonly int Block = Animator.StringToHash("Block");
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int Respawn = Animator.StringToHash("Respawn");

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        ResetHealth();
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player took damage: " + damage + " | HP: " + currentHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            if (animator != null)
                animator.SetTrigger(Block);
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;

        if (animator != null)
            animator.SetTrigger(Death);

        Debug.Log("Player died");

        Invoke(nameof(TriggerRespawn), 5.5f); // delay for death animation
    }
void UpdateHealthBar()
{
    if (healthBarFill != null)
    {
        healthBarFill.fillAmount = (float)currentHealth / maxHealth;
    }
}
    void TriggerRespawn()
    {
        // if (animator != null)
        //     animator.SetTrigger(Respawn);
        OnDeath?.Invoke();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        isDead = false;
        UpdateHealthBar();
    }
}
// using UnityEngine;

// public class PlayerHealth : MonoBehaviour
// {
//     public int maxHealth = 100;
//     public int currentHealth;

//     public System.Action OnDeath;

//     private bool isDead = false;

//     private void Start()
//     {
//         ResetHealth();
//     }

//     public void TakeDamage(int damage)
//     {
//         if (isDead) return;

//         currentHealth -= damage;
//         Debug.Log("Player took damage: " + damage + " | HP: " + currentHealth);

//         if (currentHealth <= 0)
//         {
//             Die();
//         }
//     }

//     void Die()
//     {
//         if (isDead) return;

//         isDead = true;
//         Debug.Log("Player died");


//         OnDeath?.Invoke();
//     }

//     public void ResetHealth()
//     {
//         currentHealth = maxHealth;
//         isDead = false;
//     }
// }