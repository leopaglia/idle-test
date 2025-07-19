using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class WaveManager : Singleton<WaveManager>
{
    public Transform enemyGroupAnchor;
    public TextMeshProUGUI waveText;

    public List<EnemyPattern> patterns;

    private int currentWave = 0;
    private bool waveCleared = false;

    void Start()
    {
        UpdateWaveText();
        SpawnNextWave();
    }

    private void Update()
    {
        if (!waveCleared && enemyGroupAnchor.childCount == 0)
        {
            waveCleared = true;

            float delay = patterns[currentWave - 1].delayBeforeNextWave;
            Invoke(nameof(SpawnNextWave), delay);
        }
    }

    private void SpawnNextWave()
    {
        if (currentWave >= patterns.Count)
        {
            Debug.Log("All waves complete!");
            return;
        }

        EnemyPattern pattern = patterns[currentWave];
        SpawnFromPattern(pattern);

        currentWave++;
        waveCleared = false;
        UpdateWaveText();
    }

    private void SpawnFromPattern(EnemyPattern pattern)
    {
        foreach (Vector2 offset in pattern.spawnOffsets)
        {
            Vector3 spawnPos = enemyGroupAnchor.position + (Vector3)offset;
            GameObject enemy = Instantiate(pattern.enemyPrefab, spawnPos, Quaternion.identity, enemyGroupAnchor);

            var movement = enemy.GetComponent<EnemyMovement>();
            if (movement != null)
                movement.SetPattern(pattern.movementPattern);
        }
    }

    private void UpdateWaveText()
    {
        if (waveText != null)
        {
            waveText.text = $"Wave {currentWave}";
        }
    }
}
