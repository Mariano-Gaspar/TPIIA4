// MARIANO CODUTTI ALARCON
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private WaveSet waveSet;

    private WaveData[] waves;

    [Header("UI")]
    [SerializeField] private TMP_Text waveCountdownText;
    [SerializeField] private Button startNextWaveButton;
    [SerializeField] private Image timeForNextWaveTimer;


    // WAVE STATE
    private int waveIndex = 0;
    private bool isSpawningWave = false;
    public static int enemiesAlive;


    [Header("Wave Timing")]
    [SerializeField] private float initialWaveDelay = 999f;
    [SerializeField] private float timeToSpawnNextWave = 30f;

    private float waveTimer;


    private void Start()
    {
        if (waveSet == null || waveSet.waves == null || waveSet.waves.Length == 0)
        {
            Debug.LogError("NO WAVE SET ASSIGNED!");
            this.enabled = false;
            return;
        }

        waves = waveSet.waves;

        enemiesAlive = 0;
        waveTimer = initialWaveDelay;

        startNextWaveButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        // End level if...
        // - All waves spawned
        // - All enemies are dead
        if (waveIndex == waves.Length && enemiesAlive <= 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
            return;
        }

        // If no more waves but enemies remain, do nothing.
        if (waveIndex == waves.Length)
            return;

        if (!isSpawningWave && waveTimer <= 0f)
        {
            StartCoroutine(SpawnWave());
            return;
        }

        bool canSkip = (!isSpawningWave && waveTimer > 0f);
        startNextWaveButton.gameObject.SetActive(canSkip);
        startNextWaveButton.interactable = canSkip;

        if (canSkip && waveIndex > 0)
        {
            timeForNextWaveTimer.fillAmount = waveTimer / timeToSpawnNextWave;
        }

        waveTimer -= Time.deltaTime;
        waveTimer = Mathf.Clamp(waveTimer, 0f, Mathf.Infinity);

        waveCountdownText.text = "Next wave in... " + string.Format("{0:00.00}", waveTimer) + "s";
    }


    private IEnumerator SpawnWave()
    {
        isSpawningWave = true;

        PlayerStats.waves++;

        WaveData currentWave = waves[waveIndex];

        int totalToSpawn = 0;
        foreach (var entry in currentWave.enemies)
        {
            totalToSpawn += entry.enemyAmount;
        }

        enemiesAlive += totalToSpawn;

        foreach (var entry in currentWave.enemies)
        {
            for (int i = 0; i < entry.enemyAmount; i++)
            {
                SpawnEnemy(entry.enemyPrefab);
                yield return new WaitForSeconds(1f / currentWave.spawnRate);
            }
        }

        waveTimer = timeToSpawnNextWave;

        waveIndex++;
        isSpawningWave = false;
    }

    private void SpawnEnemy(GameObject _enemyPrefab)
    {
        // Chose spawn index
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenSpawnPoint = spawnPoints[spawnIndex];
        
        // Instantiate enemy
        GameObject enemyGO = (GameObject)Instantiate(_enemyPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
        EnemyMovement target = enemyGO.GetComponent<EnemyMovement>();

        // Assign path with same index as spawn
        Transform[] chosenPath = waypoints.GetPath(spawnIndex);
        target.SetPath(chosenPath);
    }


    public int GetWavesAmount()
    {
        return waves.Length;
    }

    public void StartNextWave()
    {
        waveTimer = 0f;
        int moneyToGive = (int)(waveIndex * 10f * timeForNextWaveTimer.fillAmount);
        PlayerStats.money += moneyToGive;
        PlayerStats.score_WavesCalled += moneyToGive;
    }
}
