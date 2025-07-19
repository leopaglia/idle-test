using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    public void Initialize(int damage)
    {
        this.damage = damage;
    }
}
