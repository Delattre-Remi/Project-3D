using System;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject grassSlab;
    [SerializeField] private GameObject dirtSlab;
    [SerializeField] private Vector2 tileSize;
    [SerializeField] private Vector2 mapTileSize;
    [SerializeField] private float offset;

    [SerializeField] private Vector2[] roadPositions;

    private GameObject[,] table;
    private bool isRoad;
    private Vector3 tilePos;

    private int xTile;
    private int yTile;

    void Awake()
    {
        xTile = Mathf.FloorToInt(mapTileSize.x / 2);
        yTile = Mathf.FloorToInt(mapTileSize.y / 2);
        table = new GameObject[(int) mapTileSize.x, (int) mapTileSize.y];
        for(int i = 0 ; i < mapTileSize.x ; i++)
        {
            for(int j = 0 ; j < mapTileSize.y ; j++)
            {
                isRoad = Array.Exists(roadPositions, el => el == new Vector2(i, j));
                tilePos = new Vector3(( i - xTile ) * ( tileSize.x + offset ), 0.25f, ( j - yTile ) * ( tileSize.y + offset ));
                table[i, j] = Instantiate(isRoad ? dirtSlab : grassSlab, tilePos, Quaternion.identity, parent.transform);
            }
        }
    }

    public List<Vector3> getTilePositions()
    {
        xTile = Mathf.FloorToInt(mapTileSize.x / 2);
        yTile = Mathf.FloorToInt(mapTileSize.y / 2);
        List<Vector3> tilePositions = new List<Vector3>();
        foreach(Vector2 pos in roadPositions)
        {
            tilePos = new Vector3(( pos.x - xTile ) * ( tileSize.x + offset ), 0.25f, ( pos.y - yTile ) * ( tileSize.y + offset ));
            tilePositions.Add(tilePos);
        }
        return tilePositions;
    }
}
