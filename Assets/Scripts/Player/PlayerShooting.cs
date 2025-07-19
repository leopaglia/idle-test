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
        var tier = equippedWeapon.CurrentTier;

        if (Keyboard.current.spaceKey.isPressed &&
            Time.time >= lastShootTime + equippedWeapon.CurrentTier.cooldown)
        {
            Shoot(tier);
        }
    }

    private void Shoot(WeaponUpgradeTier tier)
    {
        int bullets = tier.bulletsPerShot;
        float angleStep = bullets > 1 ? weaponData.spreadAngle / (bullets - 1) : 0f;
        float startAngle = -weaponData.spreadAngle / 2f;

        for (int i = 0; i < bullets; i++)
        {
            float angle = startAngle + angleStep * i;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(weaponData.bulletPrefab, bulletSpawnPoint.position, rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = rotation * Vector2.up * tier.bulletSpeed;

            Bullet b = bullet.GetComponent<Bullet>();
            if (b != null)
                b.Initialize(tier.bulletDamage);

            lastShootTime = Time.time;
        }
    }
}
