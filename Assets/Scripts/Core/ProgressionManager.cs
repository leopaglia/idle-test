using TMPro;

public class ProgressionManager : Singleton<ProgressionManager>
{
    public PlayerProgressData playerProgress;
    public TextMeshProUGUI coinsText;

    public void Start()
    {
        UpdateUI();
    }

    public void AddCoins(int amount)
    {
        playerProgress.coins += amount;
        UpdateUI();
    }

    public void EnemyKilled()
    {
        playerProgress.enemiesKilled++;
    }

    //public void Prestige()
    //{
    //    playerProgress.prestigeLevel++;
    //    playerProgress.coins = 0;
    //    playerProgress.weaponLevel = 1;
    //}

    private void UpdateUI()
    {
        if (coinsText != null)
            coinsText.text = "Coins: " + playerProgress.coins;
    }
}
