using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public List<Transform> enemyList;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }
        Debug.Log(countdown);
        countdown -= Time.deltaTime;
    }

    void SpawnWave()
    {
        Debug.Log("Wave spawning");
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemyList.Add(enemyPrefab);
    }
}
