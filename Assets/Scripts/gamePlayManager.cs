using UnityEngine;

public class gamePlayManager : MonoBehaviour
{
    [SerializeField] towerManager towerManager;
    [SerializeField] UI_Updater UI_Updater;
    [SerializeField] float startingMoney;
    private float money;

    void Start()
    {
        money = startingMoney;
    }
    void Update()
    {
        UI_Updater.updateMoney(money);
    }

    public void trySpawnTower(Tower tower, Vector3 pos, Transform parent)
    {
        if(money >= tower.price)
        {
            towerManager.spawn(tower, pos, parent);
            money -= tower.price;
        }
    }
}
