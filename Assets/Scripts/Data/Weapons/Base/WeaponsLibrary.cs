using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponLibrary", menuName = "Weapons/Weapon Library")]
public class WeaponsLibrary : ScriptableObject
{
    public List<WeaponData> allWeapons;

    private Dictionary<WeaponID, WeaponData> _weaponMap;

    public void Initialize()
    {
        _weaponMap = new Dictionary<WeaponID, WeaponData>();
        foreach (var weapon in allWeapons)
        {
            if (_weaponMap.ContainsKey(weapon.weaponID))
                Debug.LogWarning($"Duplicate WeaponID: {weapon.weaponID}");

            _weaponMap[weapon.weaponID] = weapon;
        }
    }

    public WeaponData GetWeapon(WeaponID id)
    {
        if (_weaponMap == null) Initialize();
        return _weaponMap.TryGetValue(id, out var weapon) ? weapon : null;
    }

    public List<WeaponID> GetAllWeaponIDs() => new(_weaponMap.Keys);
}
