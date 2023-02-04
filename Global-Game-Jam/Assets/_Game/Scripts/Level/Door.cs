using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] DoorButton[] buttons;




    private void Awake()
    {
        foreach (var item in buttons)
        {
            item.door = this;
        }
    }


    public void Check()
    {
        foreach (var item in buttons)
        {
            if (!item.isClick)
                return;
        }

        OpenDoor();


    }
    void OpenDoor()
    {
        Debug.LogError("OPen~");
        gameObject.SetActive(false);
    }


}

