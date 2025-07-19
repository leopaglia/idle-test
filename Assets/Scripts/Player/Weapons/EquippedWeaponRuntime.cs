using UnityEngine;

public class EquippedWeaponRuntime
{
    public WeaponData data;
    public float lastShootTime = -999f;

    public WeaponID ID => data.weaponID;

    public WeaponUpgradeTier CurrentTier =>
        UpgradesManager.Instance.GetCurrentTier(ID);

    public bool CanShoot()
    {
        return Time.time >= lastShootTime + CurrentTier.cooldown;
    }

    public void MarkShotFired()
    {
        lastShootTime = Time.time;
    }
}
