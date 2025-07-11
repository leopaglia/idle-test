using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public float speed = 0.75f;
    public float moveDistance = 1f;
    public float moveDownAmount = 0f;

    private Vector3 startPosition;
    private int direction = 1;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

        if (ReachedEndOfMovement())
        {
            direction *= -1;
            startPosition = new Vector3(transform.position.x, startPosition.y, startPosition.z);
            transform.position += Vector3.down * moveDownAmount;
        }
    }

    private bool ReachedEndOfMovement()
    {
        return Mathf.Abs(transform.position.x - startPosition.x) >= moveDistance;
    }
}
