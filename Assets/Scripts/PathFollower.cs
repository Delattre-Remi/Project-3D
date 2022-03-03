using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    private List<Vector3> PathNode = new List<Vector3>();
    private Vector3 tmpNode;
    private Transform player;
    private float speed = 2;
    private int CurrentNode;
    private Vector3 startPosition;
    private Vector3 CurrentPositionHolder;
    private float Timer;
    private mapGenerator mapgenerator;
    private float positionVerticalOffset = 0.75f;

    void Start()
    {
        player = transform;
        mapgenerator = FindObjectOfType<mapGenerator>();
        PathNode = mapgenerator.getTilePositions();
        for(int i = 0 ; i < PathNode.Count ; i++)
        {
            tmpNode = PathNode[i];
            tmpNode.y += positionVerticalOffset;
            PathNode[i] = tmpNode;
        }
        CheckNode();
    }

    void CheckNode()
    {
        startPosition = player.position;
        Timer = 0;
        CurrentPositionHolder = PathNode[CurrentNode];
    }

    void Update()
    {
        Timer += Time.deltaTime * speed;
        if(( player.position - CurrentPositionHolder ).magnitude > 0.01f)
        {
            player.position = Vector3.Lerp(startPosition, CurrentPositionHolder, Timer);
        }
        else
        {
            if(CurrentNode < PathNode.Count - 1)
            {
                CurrentNode++;
                CheckNode();
            }
        }
    }
}
