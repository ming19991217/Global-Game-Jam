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
                if (LevelManager.Finish) return;
                if (button != null)
                {
                    button.Click();
                    controller.anim.SetTrigger("touch");
                    return;
                }


                if (adapter == null) return;
                if (adapter.isRoot)
                {
                    lineManager.ConnectRoot(adapter);
                }
                else if (adapter.isEnded)
                {
                    LevelManager.Win();
                    return;
                }
                else if (!adapter.isConnect)
                {
                    GameManager.Instance.PlayAddNodeAudio();
                    var i = lineManager.AddNode(adapter);
                    controller.SetRoot(adapter.transform);
                    adapter.Connect(i);
                    controller.anim.SetTrigger("touch");
                }
                else
                {
                    if (lineManager.RemoveNode(adapter, out Adapter last))
                    {
                        if (last != null)
                        {

                            GameManager.Instance.PlayRemoveNodeAudio();
                            controller.SetRoot(last.transform);
                            adapter.DisConnect();
                            controller.anim.SetTrigger("touch");
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