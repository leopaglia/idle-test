using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponStats", menuName = "Player/WeaponStats")]
public class WeaponStats : ScriptableObject
{
    public float cooldown = 0.5f;
    public int bulletsPerShot = 1;
    public float spreadAngle = 3f;
    public float bulletSpeed = 10f;
}
