using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public List<GameObject> PathNode = new List<GameObject>();
    public GameObject player;
    public float speed;
    public int CurrentNode;
    static Vector3 startPosition;
    static Vector3 CurrentPositionHolder;
    float Timer;

    void Start()
    {
        CheckNode();
    }

    void CheckNode()
    {
        Debug.Log(CurrentNode);
        startPosition = player.transform.position;
        Debug.Log(startPosition);
        Timer = 0;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
    }

    void Update()
    {
        Timer += Time.deltaTime * speed;
        if(( player.transform.position - CurrentPositionHolder ).magnitude > 0.01f)
        {
            player.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, Timer);
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
