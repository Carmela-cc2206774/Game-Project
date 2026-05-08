using UnityEngine;

public class PlayerAbilityLocks : MonoBehaviour
{
    public static PlayerAbilityLocks Instance;

    public bool movementLocked = true;
    public bool meleeLocked = true;
    public bool pickupLocked = true;
    public bool magicLocked = true;

    private void Awake()
    {
        Instance = this;
    }

    public bool AllActionLocked => movementLocked || meleeLocked || pickupLocked;
}