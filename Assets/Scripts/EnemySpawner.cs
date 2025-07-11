using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    public int enemiesPerRow = 9;
    public int numberOfRows = 4;
    public float spacingX = 0.75f;
    public float spacingY = 0.75f;
    public float startY = 3f;

    public Transform enemyGroup; 

    public void SpawnGrid()
    {
        float totalWidth = (enemiesPerRow - 1) * spacingX;
        float startX = transform.position.x - totalWidth / 2;

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < enemiesPerRow; col++)
            {
                Vector3 spawnPos = new Vector3(startX + col * spacingX, startY - row * spacingY, 0);
                GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

                enemy.transform.SetParent(enemyGroup);
            }
        }
    }
}