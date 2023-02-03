using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Adapter adapter;
    LineManager lineManager;

    private void Start()
    {
        lineManager = LineManager.Instance;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (adapter == null) return;

            lineManager.AddNode(adapter.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Adapter>(out Adapter exitAdapter))
        {
            if (adapter.Equals(exitAdapter))
                adapter = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<Adapter>(out adapter);

    }
}
