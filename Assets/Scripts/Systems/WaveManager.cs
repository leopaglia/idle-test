using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class WaveManager : Singleton<WaveManager>
{
    public List<EnemyPattern> patterns;
    public Transform enemyGroupAnchor;
    public TextMeshProUGUI waveText;

    public float delaySecondsBetweenWaves = 2f;

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
            Invoke(nameof(SpawnNextWave), delaySecondsBetweenWaves);
        }
    }

    private void SpawnNextWave()
    {
        currentWave++;
        UpdateWaveText();

        EnemyPattern selectedPattern = GetWeightedRandomPattern();
        SpawnFromPattern(selectedPattern);

        waveCleared = false;
    }

    private EnemyPattern GetWeightedRandomPattern()
    {
        int totalWeight = 0;
        foreach (var pattern in patterns)
            totalWeight += pattern.weight;

        int random = Random.Range(0, totalWeight);
        int cumulative = 0;

        foreach (var pattern in patterns)
        {
            cumulative += pattern.weight;
            if (random < cumulative)
                return pattern;
        }

        return patterns[0];
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
            waveText.text = $"Wave {currentWave}";
    }
}
