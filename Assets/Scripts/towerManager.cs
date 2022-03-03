using System.Collections.Generic;
using UnityEngine;

public class towerManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private GameObject emptyPrefab;
    private List<inGameTower> inGameTowers;
    private inGameTower tmpTower;
    private GameObject towerGameobject;
    private Renderer towerRenderer;

    void Start()
    {
        inGameTowers = new List<inGameTower>();
    }

    public void spawn(Tower tower, Vector3 pos, Transform parent)
    {
        towerGameobject = Instantiate(tower.prefab, pos, Quaternion.identity, parent);
        tmpTower = towerGameobject.AddComponent<inGameTower>();
        tmpTower.spawn(tower, towerGameobject, enemySpawner, emptyPrefab);
        inGameTowers.Add(tmpTower);
    }
}
