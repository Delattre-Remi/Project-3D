using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject spawnedEnnemy;

    [SerializeField] private Transform ennemyParent;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private Tower[] towerTypes;
    [SerializeField] private gamePlayManager manager;

    private List<GameObject> enemyList = new List<GameObject>();

    private float countdown = 2f;

    private void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }
        //Debug.Log(countdown);
        countdown -= Time.deltaTime;
    }

    void SpawnWave()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        spawnedEnnemy = Instantiate(enemyPrefab, ennemyParent.position, Quaternion.identity, ennemyParent);
        enemyList.Add(spawnedEnnemy);
        spawnedEnnemy.AddComponent<PathFollower>();
        HealthManager enemyCollider = spawnedEnnemy.AddComponent<HealthManager>();
        enemyCollider.init(towerTypes, spawnedEnnemy, enemyList, manager);
    }

    public List<GameObject> getEnemyList()
    {
        return enemyList;
    }
}
