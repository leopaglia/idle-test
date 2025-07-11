using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHP = 2;
    private int currentHP;

    public GameObject healthBarPrefab;
    private HealthBar healthBar;

    public GameObject coinPrefab;
    public int currencyDropValue = 1;

    void Start()
    {
        currentHP = maxHP;

        GameObject hb = Instantiate(healthBarPrefab, transform.position + Vector3.up * 0.3f, Quaternion.identity);
        hb.transform.SetParent(transform);
        healthBar = hb.GetComponent<HealthBar>();
        
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        UpdateHealthBar();

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        float normalizedHealth = (float)currentHP / maxHP;
        healthBar.SetHealth(normalizedHealth);
    }

    private void Die()
    {
        DropCoin();

        Destroy(healthBar.gameObject);

        Destroy(gameObject);
    }

    public void DropCoin()
    {
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        
        Coin coinScript = coin.GetComponent<Coin>();
        coinScript.value = currencyDropValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }
            
            Destroy(collision.gameObject);
        }
    }
}
