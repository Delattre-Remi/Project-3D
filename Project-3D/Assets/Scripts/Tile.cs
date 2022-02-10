using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class Tile : ScriptableObject
{
    [SerializeField] private GameObject grassTile;
    [SerializeField] private GameObject dirtTile;
    public enum tileType{
        grassTile,
        dirtTile
    };
    
}
