using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    private Canvas Canva;
    private gamePlayManager manager;
    private TextMeshProUGUI Health;
    private PathFollower pathFollower;
    private Tower[] towerTypes;
    private GameObject player;
    private Tower attacker;
    private List<GameObject> enemylist;
    private static int deadEnemies = 0;
    private static int baseHealth = 100;

    private void OnCollisionEnter(Collision collision)
    {
        Renderer renderer = collision.gameObject.GetComponent<Renderer>();
        // Tourelle par défaut
        attacker = towerTypes[0];
        foreach (Tower tower in towerTypes)
        {
            if (renderer.material.color == tower.colorChange)
            {
                attacker = tower;
            }
        }

        if(attacker.type == "Ice")
        {
            pathFollower.slow();
        }
        else if(attacker.type == "Lightning")
        {
            pathFollower.stun();
        }

        if(int.Parse(Health.text) > 0)
        {
            Health.text = HealthLoss(attacker.attackDamage).ToString();
        }
        else
        {
            if (deadEnemies % 15 == 0)
            {
                baseHealth += 20;
            }
            enemylist.Remove(player);
            Destroy(player);
            deadEnemies++;
            manager.addMoner(baseHealth / 10);

        }
        Destroy(collision.gameObject);
    }
    private float HealthLoss(float loss)
    {
        float healthvalue = int.Parse(Health.text);
        float currenthealth = healthvalue - loss;
        return currenthealth;
    }


    public void init(Tower[] _towerTypes, GameObject _player, List<GameObject> _enemylist, gamePlayManager _manager, PathFollower _pathFollower)
    {
        towerTypes = _towerTypes;
        player = _player;
        Canva = player.GetComponentInChildren<Canvas>();
        Health = Canva.GetComponentInChildren<TextMeshProUGUI>();
        Health.text = baseHealth.ToString();
        enemylist = _enemylist;
        manager = _manager;
        pathFollower = _pathFollower;
    }
}
