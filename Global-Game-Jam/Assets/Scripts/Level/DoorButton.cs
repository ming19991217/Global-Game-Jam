using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public bool isClick;
    public Door door;


    public Color clickColor;



    public void Click()
    {
        if (!isClick)
        {
            isClick = true;
            door.Check();
            this.GetComponent<Renderer>().material.color = clickColor;
            AudioManager.Instance.Play(GameManager.Instance.asset.buttonAudio);
        }
        else
        {

        }
    }



}
