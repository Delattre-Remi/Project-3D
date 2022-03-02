using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerSpawner : MonoBehaviour
{
    [SerializeField] private Tower[] towerTypes;
    [SerializeField] private towerManager towerManager;
    private Dictionary<string, Tower> towerDict;

    void Start()
    {
        towerDict = new Dictionary<string, Tower>();
        foreach(Tower tower in towerTypes) towerDict.Add(tower.type, tower);
    }

    internal void spawn(string type, Vector3 pos, Transform parent)
    {
        towerManager.spawn(towerDict[type], pos, parent);
    }
}
