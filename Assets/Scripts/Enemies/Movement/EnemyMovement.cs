using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private MovementPattern pattern;
    private float timer = 0f;

    public void SetPattern(MovementPattern newPattern)
    {
        pattern = newPattern;
    }

    private void Update()
    {
        switch (pattern)
        {
            case MovementPattern.Static:
                break;
            case MovementPattern.ZigZag:
                ZigZagMovement();
                break;
            case MovementPattern.DownThenLeftRight:
                DownThenLeftRightMovement();
                break;
        }
    }

    void ZigZagMovement()
    {
        timer += Time.deltaTime;
        float x = Mathf.Sin(timer * 3f) * 1.5f;
        transform.Translate(new Vector3(x, -1f, 0f) * Time.deltaTime);
    }

    void DownThenLeftRightMovement()
    {
        timer += Time.deltaTime;
        Vector3 direction = timer < 2.5f
            ? Vector3.down
            : Mathf.Floor(timer) % 2 == 0 ? Vector3.left : Vector3.right;

        transform.Translate(direction * Time.deltaTime);
    }
}
