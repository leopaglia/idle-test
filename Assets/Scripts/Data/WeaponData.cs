using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public WeaponID weaponID;
    public GameObject bulletPrefab;
    public float spreadAngle = 3f;
    public List<WeaponUpgradeTier> upgradeTiers = new();
}
