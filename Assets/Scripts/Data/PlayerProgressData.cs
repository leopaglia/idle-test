using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgress", menuName = "Game/Player Progress")]
public class PlayerProgressData : ScriptableObject
{
	[Header("Resources")]
	public int coins = 0;
	//public int fireCrystals = 0;
	//public int iceCrystals = 0;

	//[Header("Upgrades")]
	//public int weaponLevel = 1;
	//public bool hasUnlockedFireElement = false;
	//public bool hasUnlockedIceElement = false;

	[Header("Meta")]
	//public int prestigeLevel = 0;
	public int enemiesKilled = 0;
}
