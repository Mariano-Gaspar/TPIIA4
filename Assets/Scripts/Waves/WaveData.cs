// MARIANO CODUTTI ALARCON
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnData
{
    public GameObject enemyPrefab;
    public int enemyAmount;
}

[System.Serializable]
public class WaveData
{
    public List<EnemySpawnData> enemies;
    public float spawnRate;
}
