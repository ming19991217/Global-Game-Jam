using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public static LineManager Instance;

    int count = 2;
    int playerNode = 1;


    [SerializeField] LineRenderer line;
    [SerializeField] Transform player;

    List<Vector3> pos = new();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void FixedUpdate()
    {
        Debug.Log(playerNode + "||" + line.positionCount);
        line.SetPosition(playerNode, player.transform.position);
    }


    public void AddNode(Vector3 pos)
    {
        Vector3[] newPos = new Vector3[line.positionCount];
        line.GetPositions(newPos);


        List<Vector3> posLis = new(newPos);
        posLis[posLis.Count - 1] = pos;
        posLis.Add(player.position);

        line.positionCount = posLis.Count;
        line.SetPositions(posLis.ToArray());
        playerNode++;

        // line.SetPositions()
    }
}
