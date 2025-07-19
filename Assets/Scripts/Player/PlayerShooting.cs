using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public WeaponStats currentWeaponStats;

    private float lastShootTime;

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed && Time.time >= lastShootTime + currentWeaponStats.cooldown)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        int bullets = currentWeaponStats.bulletsPerShot;
        float angleStep = bullets > 1 ? currentWeaponStats.spreadAngle / (bullets - 1) : 0f;
        float startAngle = -currentWeaponStats.spreadAngle / 2f;

        for (int i = 0; i < bullets; i++)
        {
            float angle = startAngle + angleStep * i;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = rotation * Vector2.up * currentWeaponStats.bulletSpeed;
            }

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.Initialize(1); // For now, 1 damage � make dynamic later
            }
        }

        lastShootTime = Time.time;
    }
}
