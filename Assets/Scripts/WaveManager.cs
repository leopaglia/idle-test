using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public EnemySpawner spawner;
    public Transform enemyGroup;
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
        if (!waveCleared && enemyGroup.childCount == 0)
        {
            waveCleared = true;
            Invoke(nameof(SpawnNextWave), delaySecondsBetweenWaves);
        }
    }

    private void SpawnNextWave()
    {
        currentWave++;
        spawner.SpawnGrid();
        waveCleared = false;
        UpdateWaveText();
    }

    void UpdateWaveText()
    {
        if (waveText != null)
        {
            waveText.text = $"Wave {currentWave}";
        }
    }
}