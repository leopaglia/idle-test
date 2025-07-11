using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public float fallSpeed = 4f;

    private float lifetime = 5f;
    private bool collected = false;

    private float spawnTime;

    void Start()
    {
        spawnTime = Time.time;
        Destroy(gameObject, lifetime);
    }


    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collected || !collision.CompareTag("Player")) return;

        collected = true;

        CurrencyManager.Instance.AddCurrency(value);
        Destroy(gameObject);
    }
}
