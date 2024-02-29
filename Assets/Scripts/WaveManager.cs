using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 3f;
    public int enemiesPerWave = 1;

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            SpawnWave();
            currentWave++;
            enemiesPerWave += 2;
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        int randomTerroristIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomTerroristIndex], randomSpawnPoint.position, enemyPrefabs[randomTerroristIndex].transform.rotation);
    }
}
