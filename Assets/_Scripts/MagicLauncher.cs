using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class MagicLauncher : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject lightOrbPrefab;
    public GameObject heavyOrbPrefab;

    public Transform firePoint;
    public Animator animator;

    [Header("Forces")]
    public float lightForce = 18f;
    public float heavyForce = 10f;

    [Header("Cooldowns")]
    public float lightCooldown = 1f;
    public float heavyCooldown = 17f;

    private float nextLightTime = 0f;
    private float nextHeavyTime = 0f;

    private void Start()
    {
        if (firePoint == null)
        {
            firePoint = FindChildByName(transform, "FirePoint");
            Debug.Log("Punch point found: " + (firePoint != null ? firePoint.name : "NULL"));
        }

        // if (kickPoint == null)
        // {
        //     kickPoint = FindChildByName(transform, "KickPoint");
        //     Debug.Log("Kick point found: " + (kickPoint != null ? kickPoint.name : "NULL"));
        // }
    }

    void Update()
    {
        // 🔹 LIGHT CAST (Key 4)
        if (Keyboard.current != null &&
            Keyboard.current.digit4Key.wasPressedThisFrame &&
            Time.time >= nextLightTime)
        {
            nextLightTime = Time.time + lightCooldown;

            animator?.SetTrigger("MagicAttack");

            StartCoroutine(FireWithDelay(0.5f, lightOrbPrefab, lightForce));
        }

        // 🔸 HEAVY CAST (Key 5)
        if (Keyboard.current != null &&
            Keyboard.current.digit5Key.wasPressedThisFrame &&
            Time.time >= nextHeavyTime)
        {
            nextHeavyTime = Time.time + heavyCooldown;

            animator?.SetTrigger("MagicAreaAttack");

            StartCoroutine(FireWithDelay(0.8f, heavyOrbPrefab, heavyForce));
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
    IEnumerator FireWithDelay(float delay, GameObject prefab, float force)
    {
        yield return new WaitForSeconds(delay);
        Shoot(prefab, force);
    }

    // void Shoot(GameObject prefab, float force)
    // {
    //     if (prefab == null || firePoint == null) return;

    //     GameObject orb = Instantiate(
    //         prefab,
    //         firePoint.position,
    //         Quaternion.LookRotation(transform.forward)
    //     );

    //     Rigidbody rb = orb.GetComponent<Rigidbody>();
    //     if (rb == null) return;

    //     rb.useGravity = false;

    //     Vector3 direction = transform.forward;
    //     direction.y += 0.1f;
    //     direction.Normalize();

    //     rb.linearVelocity = direction * force;

    //     Destroy(orb, 5f);
    // }
    void Shoot(GameObject prefab, float force)
{
    if (prefab == null)
    {
        Debug.LogError("Magic orb prefab is missing.");
        return;
    }

    if (firePoint == null)
    {
        Debug.LogError("FirePoint is missing.");
        return;
    }

    Debug.Log("Spawning magic orb: " + prefab.name);

    GameObject orb = Instantiate(
        prefab,
        firePoint.position,
        Quaternion.LookRotation(transform.forward)
    );

    Rigidbody rb = orb.GetComponent<Rigidbody>();
    if (rb == null)
    {
        Debug.LogError("Magic orb has no Rigidbody.");
        return;
    }

    rb.useGravity = false;

    Vector3 direction = transform.forward;
    direction.y += 0.1f;
    direction.Normalize();

    rb.linearVelocity = direction * force;

    Destroy(orb, 5f);
}
}