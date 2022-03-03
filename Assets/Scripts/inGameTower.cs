using System.Collections.Generic;
using UnityEngine;

public class inGameTower : MonoBehaviour
{
    private GameObject emptyPrefab;
    private Tower tower;
    private Vector3 pos;
    private Renderer towerRenderer;
    private GameObject towerGameobject;
    private EnemySpawner enemySpawner;
    private List<GameObject> enemyList = new List<GameObject>();
    private GameObject firstEnemy;
    private Vector3 vectorToShoot;
    private Rigidbody rb;
    private float countdown = 0f;
    private float factor = 0.001f;

    public void spawn(Tower _tower, GameObject _towerGameobject, EnemySpawner _enemySpawner, GameObject _emptyPrefab)
    {
        tower = _tower;
        towerGameobject = _towerGameobject;
        enemySpawner = _enemySpawner;
        emptyPrefab = _emptyPrefab;
        pos = towerGameobject.transform.position;
        enemyList = enemySpawner.getEnemyList();
        towerRenderer = gameObject.GetComponent<Renderer>();
        towerRenderer.material.color = tower.colorChange;
    }

    private GameObject findFirstCloseEnoughEnemy(List<GameObject> enemyList)
    {
        float dist;
        foreach(GameObject enemy in enemyList)
        {
            dist = Vector3.Distance(enemy.transform.position, pos);
            if(dist < tower.attackRange)
            {
                return enemy;
            }
        }
        return emptyPrefab;
    }

    public void shoot()
    {
        firstEnemy = findFirstCloseEnoughEnemy(enemyList);
        if(firstEnemy != emptyPrefab)
        {
            GameObject bullet = Instantiate(tower.attackPrefab, pos, Quaternion.Euler(vectorToShoot), towerGameobject.transform);
            Renderer rd = bullet.GetComponent<Renderer>();
            rd.material.color = tower.colorChange;
            vectorToShoot = firstEnemy.transform.position - pos;
            vectorToShoot.Normalize();
            bullet.transform.localScale = new Vector3(factor, factor, factor);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(vectorToShoot * 1000);
        }
    }

    private void Update()
    {
        if(countdown <= 0f)
        {
            shoot();
            countdown = 1 / tower.attackSpeed;
        }
        countdown -= Time.deltaTime;
    }
}
