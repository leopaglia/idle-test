using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Basic Weapon")]
public class BasicWeapon : WeaponData
{
    public float spreadAngle = 3f;

    public override void Shoot(Transform playerTransform, Transform spawnPoint, EquippedWeaponRuntime runtime)
    {
        if (!runtime.CanShoot())
            return;

        var tier = runtime.CurrentTier;

        int bullets = tier.bulletsPerShot;
        float angleStep = bullets > 1 ? spreadAngle / (bullets - 1) : 0f;
        float startAngle = -spreadAngle / 2f;

        for (int i = 0; i < bullets; i++)
        {
            float angle = startAngle + angleStep * i;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = rotation * Vector2.up * tier.bulletSpeed;

            Bullet b = bullet.GetComponent<Bullet>();
            if (b != null)
                b.Initialize(tier.bulletDamage);
        }

        runtime.MarkShotFired();
    }
}
