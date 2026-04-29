using UnityEngine;

public class EnemyHealthBarFollow : MonoBehaviour
{
    public Transform enemy;
    public Vector3 offset = new Vector3(0, 2.2f, 0);

    void LateUpdate()
    {
        if (enemy == null) return;

        transform.position = enemy.position + offset;

        if (Camera.main != null)
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}