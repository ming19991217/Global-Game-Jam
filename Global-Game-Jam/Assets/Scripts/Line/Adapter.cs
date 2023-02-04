using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adapter : MonoBehaviour
{

    public bool isConnect;
    public int lineId;
    public bool isRoot;

    public void Connect(int lineId)
    {
        if (isConnect == false)
        {
            isConnect = true;
            this.lineId = lineId;
        }
    }

    public void DisConnect()
    {
        if (isConnect)
        {
            isConnect = false;
            this.lineId = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }





}
