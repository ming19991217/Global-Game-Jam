using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public bool isClick;
    [HideInInspector] public Door door;
    Material material;


    public Renderer renderer;
    void Awake()
    {
        material = this.GetComponent<Renderer>().material;
    }



    public void Click()
    {
        if (!isClick)
        {
            AudioManager.Instance.Play(GameManager.Instance.asset.buttonAudio);
            isClick = true;
            door.Check();
            material.SetColor ("_EmissionColor", Color.green);
        }
        else
        {

        }
    }



}
