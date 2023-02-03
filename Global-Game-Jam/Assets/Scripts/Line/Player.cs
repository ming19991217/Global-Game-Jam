using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    public class Player : MonoBehaviour
    {

        Adapter adapter;
        LineManager lineManager;
        PlayerController controller;



        private void Start()
        {
            lineManager = LineManager.Instance;
            controller = GetComponent<PlayerController>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (adapter == null) return;

                if (!adapter.isConnect)
                {
                    var i = lineManager.AddNode(adapter);
                    controller.SetRoot(adapter.transform);
                    adapter.Connect(i);
                }
                else
                {
                    if (lineManager.RemoveNode(adapter, out Adapter last))
                    {
                        if (last != null)
                        {
                            controller.SetRoot(last.transform);
                            adapter.DisConnect();
                        }
                        else
                        {

                        }
                    }
                }


            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Adapter>(out Adapter exitAdapter))
            {
                if (adapter == null) return;
                if (adapter.Equals(exitAdapter))
                    adapter = null;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent<Adapter>(out adapter);

        }
    }

}