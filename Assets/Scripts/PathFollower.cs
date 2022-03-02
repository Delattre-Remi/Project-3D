using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public List<Vector3> PathNode = new List<Vector3>();
    Vector3 tmpNode;
    public GameObject player;
    public float speed;
    public int CurrentNode;
    static Vector3 startPosition;
    static Vector3 CurrentPositionHolder;
    float Timer;
    [SerializeField] mapGenerator mapgenerator;
    public float positionVerticalOffset;

    void Start()
    {
        PathNode = mapgenerator.getTilePositions();
        for (int i = 0; i < PathNode.Count; i++)
        {
            tmpNode = PathNode[i];
            tmpNode.y += positionVerticalOffset;
            PathNode[i] = tmpNode;
        }
        CheckNode();
    }

    void CheckNode()
    {
        //Debug.Log(CurrentNode);
        startPosition = player.transform.position;
        //Debug.Log(startPosition);
        Timer = 0;
        CurrentPositionHolder = PathNode[CurrentNode];
    }

    void Update()
    {
        Timer += Time.deltaTime * speed;
        if ((player.transform.position - CurrentPositionHolder).magnitude > 0.01f)
        {
            player.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, Timer);
        }
        else
        {
            if (CurrentNode < PathNode.Count - 1)
            {
                CurrentNode++;
                CheckNode();
            }
        }
    }
}
