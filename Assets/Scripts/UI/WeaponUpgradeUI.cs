using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeUI : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI weaponNameText;
    public Button upgradeButton;
    public TextMeshProUGUI upgradeButtonText;

    [Header("Dependencies")]
    public PlayerShooting playerShooting;

    private void Start()
    {
        upgradeButton.onClick.AddListener(OnUpgradeClicked);
    }

    private void Update()
    {
        if (playerShooting?.equippedWeapon == null) return;
        
        RefreshUI();
    }

    private void OnUpgradeClicked()
    {
        var equippedWeaponID = playerShooting.equippedWeapon.ID;
        var successfulUpgrade = UpgradesManager.Instance.TryPurchaseUpgrade(equippedWeaponID);
        
        if (successfulUpgrade)
        {
            RefreshUI();
        }
    }

    public void RefreshUI()
    {
        if (playerShooting == null || playerShooting.equippedWeapon == null)
            return;

        var equippedWeaponID = playerShooting.equippedWeapon.ID;
        var currentLevel = UpgradesManager.Instance.GetWeaponLevel(equippedWeaponID);
        var tier = UpgradesManager.Instance.GetCurrentTier(equippedWeaponID);

        weaponNameText.text = $"{equippedWeaponID} LV{currentLevel}";

        if (UpgradesManager.Instance.HasUpgradesAvailable(equippedWeaponID))
        {
            int cost = UpgradesManager.Instance.GetNextUpgradeCost(equippedWeaponID);
            upgradeButtonText.text = $"Upgrade \nCost: {cost}";
            upgradeButton.interactable = ProgressionManager.Instance.playerProgress.coins >= cost;
        }
        else
        {
            upgradeButtonText.text = "Max Level";
            upgradeButton.interactable = false;
        }
    }
}
