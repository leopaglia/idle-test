using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class WeaponUpgradeManager : Singleton<WeaponUpgradeManager>
{
    public WeaponStats stats;
    public int currentLevel = 1;

	public List<WeaponUpgradeTier> upgradeTiers;

	protected override void Awake()
	{ 
		base.Awake();

		upgradeTiers = new List<WeaponUpgradeTier>
		{
			new WeaponUpgradeTier { cooldown = 0.25f, bulletsPerShot = 1, bulletSpeed = 10f },
			new WeaponUpgradeTier { cooldown = 0.20f, bulletsPerShot = 1, bulletSpeed = 10f },
			new WeaponUpgradeTier { cooldown = 0.15f, bulletsPerShot = 2, bulletSpeed = 10f },
			new WeaponUpgradeTier { cooldown = 0.15f, bulletsPerShot = 2, bulletSpeed = 15f },
			new WeaponUpgradeTier { cooldown = 0.10f, bulletsPerShot = 3, bulletSpeed = 20f }
		};
	} 

	private void Update()
	{
		if (Keyboard.current.uKey.wasPressedThisFrame)
		{
			Upgrade();
		}

		if (Keyboard.current.dKey.wasPressedThisFrame)
		{
			Downgrade();
		}
	}

	private void OnGUI()
	{
		GUILayout.BeginArea(new Rect(50, 10, 250, 120));
		GUILayout.Label($"<b>Weapon Debug</b>");
		GUILayout.Label($"Level: {currentLevel}");
		GUILayout.Label($"Cooldown: {stats.cooldown:F2}s");
		GUILayout.Label($"Bullets per shot: {stats.bulletsPerShot}");
		GUILayout.Label($"Bullet Speed: {stats.bulletSpeed}");
		GUILayout.EndArea();
	}


	private void Upgrade()
	{
		if (currentLevel >= upgradeTiers.Count) return;

		currentLevel++;
		UpdateStats();
		Debug.Log($"[Upgrade] Weapon upgraded to level {currentLevel}");
	}


	private void Downgrade()
	{
		if (currentLevel == 1) return;

		currentLevel--;
		UpdateStats();
		Debug.Log($"[Upgrade] Weapon downgraded to level {currentLevel}");
	}

	private void UpdateStats()
	{
		var tier = upgradeTiers[currentLevel - 1];

		stats.cooldown = tier.cooldown;
		stats.bulletsPerShot = tier.bulletsPerShot;
		stats.bulletSpeed = tier.bulletSpeed;
	}
}
