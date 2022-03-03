using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    private Canvas Canva;
    private TextMeshProUGUI Health;
    [SerializeField] private Tower[] towerTypes;
    private GameObject player;
    Tower attacker;
    List<GameObject> enemylist;
    private static int deadEnemies = 0;
    private static int baseHealth = 100;
    private gamePlayManager manager;


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
        if (int.Parse(Health.text) > 0)
        {
            Health.text = HealthLoss(attacker.attackDamage).ToString();
        }
        else
        {
            if (deadEnemies % 15 == 0)
            {
                baseHealth += 100;
            }
            enemylist.Remove(player);
            Destroy(player);
            deadEnemies++;
            Debug.Log(manager);
            manager.addMoner(baseHealth / 100);

        }
        Destroy(collision.gameObject);
    }
    private float HealthLoss(float loss)
    {
        //Debug.Log(Health);
        float healthvalue = int.Parse(Health.text);
        float currenthealth = healthvalue - loss;
        return currenthealth;
    }


    public void init(Tower[] _towerTypes, GameObject _player, List<GameObject> _enemylist, gamePlayManager _manager)
    {
        towerTypes = _towerTypes;
        player = _player;
        Canva = player.GetComponentInChildren<Canvas>();
        Health = Canva.GetComponentInChildren<TextMeshProUGUI>();
        Health.text = baseHealth.ToString();
        enemylist = _enemylist;
        manager = _manager;
    }
}
