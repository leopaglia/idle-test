using UnityEngine;
using UnityEngine.InputSystem;

public class DebugController : MonoBehaviour
{
    public PlayerShooting player;

    void Update()
    {
        if (Keyboard.current.uKey.wasPressedThisFrame)
        {
            var weaponID = player.equippedWeapon.ID;
            UpgradesManager.Instance.UpgradeWeapon(weaponID);
        }

        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            var weaponID = player.equippedWeapon.ID;
            UpgradesManager.Instance.DowngradeWeapon(weaponID);
        }
    }
}
