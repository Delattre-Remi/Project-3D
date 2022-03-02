using System.Collections.Generic;
using UnityEngine;

public class towerSpawner : MonoBehaviour
{
    [SerializeField] private gamePlayManager gamePlayManager;
    [SerializeField] private Tower[] towerTypes;
    private Dictionary<string, Tower> towerDict;

    void Start()
    {
        towerDict = new Dictionary<string, Tower>();
        foreach(Tower tower in towerTypes) towerDict.Add(tower.type, tower);
    }

    internal void spawn(string type, Vector3 pos, Transform parent)
    {
        gamePlayManager.trySpawnTower(towerDict[type], pos, parent);
    }
}
