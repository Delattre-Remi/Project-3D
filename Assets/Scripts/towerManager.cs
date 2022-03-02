using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameTower : ScriptableObject
{
    private Tower tower;
    private Vector3 pos;
    private Transform parent;
    private GameObject gameObject;
    private Renderer renderer;
    public void spawn(Tower _tower, Vector3 _pos, Transform _parent)
    {
        tower = _tower;
        pos = _pos;
        parent = _parent;
        gameObject = Instantiate(tower.prefab, pos, Quaternion.identity, parent);
        renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = tower.colorChange;
    }
}

public class towerManager : MonoBehaviour
{
    private List<inGameTower> inGameTowers;
    private inGameTower tmpTower;

    void Start()
    {
        inGameTowers = new List<inGameTower>();
    }

    public void spawn(Tower tower, Vector3 pos, Transform parent)
    {
        tmpTower = ScriptableObject.CreateInstance<inGameTower>();
        tmpTower.spawn(tower, pos, parent);
        inGameTowers.Add(tmpTower);
    }
}
