using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float speed = 10f;
    public float lifetime = 2f;

    private float timer;

    void OnEnable()
    {
        timer = 0f;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if(timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
