using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class UpgradesManager : Singleton<UpgradesManager>
{
    public List<WeaponData> allWeapons;

    private Dictionary<WeaponID, int> weaponLevels = new();
    private HashSet<WeaponID> unlockedWeapons = new();

    private void Start()
    {
        UnlockWeapon(WeaponID.Basic);

        Debug.Log(weaponLevels[WeaponID.Basic]);
    }

    public void UpgradeWeapon(WeaponID id)
    {
        if (!IsWeaponUnlocked(id)) return;

        var weapon = GetWeaponByID(id);
        if (weapon == null) return;

        int currentLevel = GetWeaponLevel(id);

        if (currentLevel == weapon.upgradeTiers.Count) return;

        weaponLevels[id] = currentLevel + 1;
        Debug.Log($"Weapon {id} upgraded to level {weaponLevels[id]}");
    }

    public void DowngradeWeapon(WeaponID id)
    {
        if (!IsWeaponUnlocked(id)) return;

        var weapon = GetWeaponByID(id);
        if (weapon == null) return;

        int currentLevel = GetWeaponLevel(id);

        if (currentLevel == 1) return;

        weaponLevels[id] = currentLevel - 1;
        Debug.Log($"Weapon {id} downgraded to level {weaponLevels[id]}");
    }

    public void UnlockWeapon(WeaponID id)
    {
        unlockedWeapons.Add(id);
        if (!weaponLevels.ContainsKey(id))
            weaponLevels[id] = 1;
    }

    public WeaponUpgradeTier GetCurrentTier(WeaponID id)
    {
        var weapon = GetWeaponByID(id);
        if (weapon == null) return null;

        int currentLevel = GetWeaponLevel(id);
        return weapon.upgradeTiers[currentLevel - 1];
    }

    public int GetWeaponLevel(WeaponID id) => weaponLevels.TryGetValue(id, out int lvl) ? lvl : 0;

    public bool IsWeaponUnlocked(WeaponID id) => unlockedWeapons.Contains(id);

    private WeaponData GetWeaponByID(WeaponID id) => allWeapons.Find(w => w.weaponID == id);
}