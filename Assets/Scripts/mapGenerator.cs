using System;
using System.Collections;
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

    void Start()
    {
        int xTile = Mathf.FloorToInt(mapTileSize.x / 2);
        int yTile = Mathf.FloorToInt(mapTileSize.y / 2);
        table = new GameObject[(int)mapTileSize.x, (int)mapTileSize.y];
        for (int i = 0; i < mapTileSize.x; i++)
        {
            for (int j = 0; j < mapTileSize.y; j++)
            {
                isRoad = Array.Exists(roadPositions, el => el == new Vector2(i, j));
                table[i, j] = Instantiate(isRoad ? dirtSlab : grassSlab, new Vector3((i - xTile) * (tileSize.x + offset), 0.25f, (j - yTile) * (tileSize.y + offset)), Quaternion.identity, parent.transform); ;
            }
        }
    }
}
