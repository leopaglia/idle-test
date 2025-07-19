using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public float fallSpeed = 4f;

    private bool collected = false;

    private float spawnTime;

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collected || !collision.CompareTag("Player")) return;

        collected = true;

        ProgressionManager.Instance.AddCoins(value);
        Destroy(gameObject);
    }
}
