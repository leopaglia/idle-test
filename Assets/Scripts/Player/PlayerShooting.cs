using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public WeaponData weaponData;
    public Transform bulletSpawnPoint;

    public EquippedWeaponRuntime equippedWeapon;

    private float lastShootTime;

    private void Start()
    {
        equippedWeapon = new EquippedWeaponRuntime { data = weaponData };
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.isPressed &&
            Time.time >= lastShootTime + equippedWeapon.CurrentTier.cooldown)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // TODO: eventually, shoot all weapons attached
        equippedWeapon.data.Shoot(transform, bulletSpawnPoint, equippedWeapon);
    }
}
