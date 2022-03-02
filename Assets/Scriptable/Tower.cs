using UnityEngine;

[CreateAssetMenu]
public class Tower : ScriptableObject
{
    public string type;
    public GameObject prefab;
    public int price;
    public float attackSpeed;
    public float attackDamage;
    public Sprite attackSprite;
    public Color colorChange;
    public GameObject target;
}