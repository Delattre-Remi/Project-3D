using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    [SerializeField] private Transform[] checkPoints;

    private void DrawPath()
    {
        for(int i = 0 ; i < checkPoints.Length ; i++)
        {
            Gizmos.DrawLine(new Vector2(checkPoints[i].position.x, checkPoints[i].position.y), new Vector2(checkPoints[i + 1].position.x, checkPoints[i + 1].position.y));
        }
    }
}