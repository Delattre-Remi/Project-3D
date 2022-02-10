using UnityEngine;


[CreateAssetMenu]
public class Tower : ScriptableObject
{
    [SerializeField] private string type;
    [SerializeField] private Sprite sprite;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackDamage;
    [SerializeField] private Sprite attackSprite;
    [SerializeField] private Color colorChange;
}