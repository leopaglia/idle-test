using UnityEngine;
using System.Collections.Generic;

public abstract class WeaponData : ScriptableObject
{
    public WeaponID weaponID;
    public GameObject bulletPrefab;
    public List<WeaponUpgradeTier> upgradeTiers = new();

    public abstract void Shoot(Transform playerTransform, Transform spawnPoint, EquippedWeaponRuntime runtime);
}
