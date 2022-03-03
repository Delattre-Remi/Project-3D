using UnityEngine;

[CreateAssetMenu]
public class Tower : ScriptableObject
{
    public string type;
    public GameObject prefab;
    public int price;
    public GameObject attackPrefab;
    public float attackSpeed;
    public float attackDamage;
    public float attackRange;
    public Color colorChange;
}