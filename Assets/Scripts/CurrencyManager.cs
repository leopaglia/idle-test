using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    public TextMeshProUGUI currencyText;
    public int currency = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
