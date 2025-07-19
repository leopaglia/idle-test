using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

// TODO: fix current level 1-based index
public class UpgradesManager : Singleton<UpgradesManager>
{
    public WeaponsLibrary weaponsLibrary;

    private Dictionary<WeaponID, int> weaponLevels = new();
    private HashSet<WeaponID> unlockedWeapons = new();

    private void Start()
    {
        UnlockWeapon(WeaponID.Basic);
    }

    public bool TryPurchaseUpgrade(WeaponID id)
    {
        if (!IsWeaponUnlocked(id)) return false;

        var weapon = weaponsLibrary.GetWeapon(id);
        if (weapon == null)
        {
            Debug.Log($"[Upgrade] Weapon {id} not found.");
            return false;
        }

        int currentLevel = GetWeaponLevel(id);
        if (currentLevel == weapon.upgradeTiers.Count)
        {
            Debug.Log($"[Upgrade] Weapon already at max level ({currentLevel}/{weapon.upgradeTiers.Count})");
            return false;
        }

        var nextTier = weapon.upgradeTiers[currentLevel];
        int cost = nextTier.cost;

        if (ProgressionManager.Instance.playerProgress.coins < cost)
        {
            Debug.Log($"[Upgrade] Not enough coins for upgrade. Needed: {cost}");
            return false;
        }

        ProgressionManager.Instance.SpendCoins(cost);
        UpgradeWeapon(id);
        Debug.Log($"[Upgrade] Upgraded {id} to level {weaponLevels[id]} (Cost: {cost})");
        return true;
    }

    public void UpgradeWeapon(WeaponID id)
    {
        if (!IsWeaponUnlocked(id)) return;

        var weapon = weaponsLibrary.GetWeapon(id);
        if (weapon == null) return;

        int currentLevel = GetWeaponLevel(id);
        if (currentLevel == weapon.upgradeTiers.Count) return;

        weaponLevels[id] = currentLevel + 1;
    }

    public void DowngradeWeapon(WeaponID id)
    {
        if (!IsWeaponUnlocked(id)) return;

        var weapon = weaponsLibrary.GetWeapon(id);
        if (weapon == null) return;

        int currentLevel = GetWeaponLevel(id);
        if (currentLevel == 1) return;

        weaponLevels[id] = currentLevel - 1;
    }

    public void UnlockWeapon(WeaponID id)
    {
        unlockedWeapons.Add(id);
        if (!weaponLevels.ContainsKey(id))
            weaponLevels[id] = 1;
    }

    public WeaponUpgradeTier GetCurrentTier(WeaponID id)
    {
        var weapon = weaponsLibrary.GetWeapon(id);
        if (weapon == null) return null;

        int currentLevel = GetWeaponLevel(id);
        return weapon.upgradeTiers[currentLevel - 1];
    }

    public bool HasUpgradesAvailable(WeaponID id)
    {
        var weapon = weaponsLibrary.GetWeapon(id);
        if (weapon == null) return false;

        int currentLevel = GetWeaponLevel(id);

        Debug.Log($"current: {currentLevel}, amount of upgrades: {weapon.upgradeTiers.Count}, hasNext: {currentLevel < weapon.upgradeTiers.Count}");
        
        return currentLevel < weapon.upgradeTiers.Count;
    }

    public int GetNextUpgradeCost(WeaponID id)
    {
        var weapon = weaponsLibrary.GetWeapon(id);
        if (weapon == null) return 0;
        if (!HasUpgradesAvailable(id)) return 0;

        int currentLevel = GetWeaponLevel(id);
        return weapon.upgradeTiers[currentLevel].cost;
    }

    public int GetWeaponLevel(WeaponID id) => weaponLevels.TryGetValue(id, out int lvl) ? lvl : 0;

    public bool IsWeaponUnlocked(WeaponID id) => unlockedWeapons.Contains(id);
}