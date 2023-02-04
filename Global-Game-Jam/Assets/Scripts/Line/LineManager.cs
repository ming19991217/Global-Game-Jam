using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public static LineManager Instance;

    public static Action<int> OnAddNode;
    public static Action<int> OnRemoveNode;


    int playerNode = 1;

    List<Adapter> adapters;

    [SerializeField] LineRenderer line;
    [SerializeField] Transform player;
    [SerializeField] Adapter root;

    List<Vector3> pos = new();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        adapters = new();
        adapters.Add(root);


    }

    private void FixedUpdate()
    {
        Debug.Log(playerNode);
        line.SetPosition(playerNode, player.transform.position);
    }

    public bool RemoveNode(Adapter removeNode, out Adapter lastAdapter)
    {
        lastAdapter = null;

        int i = adapters.IndexOf(removeNode);

        if (i != adapters.Count - 1) return false;
        if (i == 0) return false;

        adapters.Remove(removeNode);
        lastAdapter = adapters[adapters.Count - 1];

        line.positionCount = adapters.Count + 1;
        List<Vector3> newList = new();
        foreach (var item in adapters)
            newList.Add(item.transform.position);
        newList.Add(Vector3.zero);
        line.SetPositions(newList.ToArray());
        playerNode--;

        OnAddNode?.Invoke(adapters.Count);

        return true;

    }

    public void ConnectRoot(Adapter root)
    {
        if (LevelManager.Finish)
        {
            AddNode(root);
            LevelManager.Win();
        }


    }

    public int AddNode(Adapter adapter)
    {

        Vector3[] newPos = new Vector3[line.positionCount];
        line.GetPositions(newPos);


        List<Vector3> posLis = new(newPos);
        int i = posLis.Count - 1;
        posLis[i] = adapter.transform.position;
        posLis.Add(player.position);
        adapters.Add(adapter);

        line.positionCount = posLis.Count;
        line.SetPositions(posLis.ToArray());
        playerNode++;

        OnRemoveNode?.Invoke(adapters.Count);


        return i;

        // line.SetPositions()
    }
}
