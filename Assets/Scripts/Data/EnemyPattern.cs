using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyPattern", menuName = "Enemy/Pattern")]
public class EnemyPattern: ScriptableObject
{
    public GameObject enemyPrefab;
    public Vector2[] spawnOffsets;
    public MovementPattern movementPattern;

    [Range(1, 100)]
    public int weight = 10; // Probability of random selection
}