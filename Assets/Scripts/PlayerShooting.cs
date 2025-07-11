using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootCooldown = 0.25f;

    private float lastShootTime;

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        lastShootTime = Time.time;
    }
}
