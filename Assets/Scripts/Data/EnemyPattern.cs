using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyPattern", menuName = "Enemy/Pattern")]
public class EnemyPattern: ScriptableObject
{
    public GameObject enemyPrefab;
    public Vector2[] spawnOffsets;
    public MovementPattern movementPattern;
    public float delayBeforeNextWave;
}