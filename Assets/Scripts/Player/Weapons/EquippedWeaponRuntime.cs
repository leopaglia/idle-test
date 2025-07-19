public class EquippedWeaponRuntime
{
    public WeaponData data;

    public WeaponID ID => data.weaponID;

    public WeaponUpgradeTier CurrentTier =>
        UpgradesManager.Instance.GetCurrentTier(ID);
}
