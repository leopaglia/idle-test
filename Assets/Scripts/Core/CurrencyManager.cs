using UnityEngine;
using TMPro;

public class CurrencyManager : Singleton<CurrencyManager>
{
    public TextMeshProUGUI currencyText;
    public int currency = 0;

    private void Start()
    {
        UpdateUI();
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        UpdateUI();
    }

    public bool SpendCurrency(int amount)
    {
        if (currency >= amount)
        {
            currency -= amount;
            UpdateUI();
            return true;
        }

        return false;
    }

    private void UpdateUI()
    {
        if (currencyText != null)
        {
            currencyText.text = "Coins: " + currency;
        }
    }
}
