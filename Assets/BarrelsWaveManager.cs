using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelsWaveManager : MonoBehaviour
{
    public GameObject[] barrelPrefabs;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 7.5f;
    public int barrelsPerWave = 1;

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnBarrelWaves());
    }

    IEnumerator SpawnBarrelWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            SpawnWave();
            currentWave++;
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < barrelsPerWave; i++)
        {
            SpawnBarrel();
        }
    }

    void SpawnBarrel()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject randomBarrel = barrelPrefabs[Random.Range(0, barrelPrefabs.Length)];
        Instantiate(randomBarrel, randomSpawnPoint.position, randomBarrel.transform.rotation);
    }
}
