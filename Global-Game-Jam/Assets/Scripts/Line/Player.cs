using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    public class Player : MonoBehaviour
    {

        Adapter adapter;
        DoorButton button;
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
                if (button != null)
                {
                    button.Click();
                    return;
                }


                if (adapter == null) return;
                if (adapter.isRoot)
                {
                    lineManager.ConnectRoot(adapter);
                }
                else if (!adapter.isConnect)
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
            if (other.TryGetComponent<DoorButton>(out DoorButton exitBtn))
            {
                if (button == null) return;
                if (button.Equals(exitBtn))
                    button = null;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent<Adapter>(out adapter);
            other.TryGetComponent<DoorButton>(out button);

        }
    }

}