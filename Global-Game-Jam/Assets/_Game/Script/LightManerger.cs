using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManerger : MonoBehaviour
{
    [SerializeField]
    public GameObject[] lightsObjs;
    List<Material>  materials;
    public Adapter adapter;
    public bool isOpen = false;



    void Awake()
    {
        adapter = this.GetComponent<Adapter>();
        materials=new();
        foreach(var item in lightsObjs)
        {   
            Renderer renderer = item.GetComponent<Renderer> ();
            materials.Add(renderer.material);
        }
    }

    void LightsContral(Material mat)
    {
            mat.EnableKeyword("_EMISSION");
         float emission = Mathf.PingPong (Time.time, 1.0f);
         Color baseColor = Color.cyan; //Replace t$$anonymous$$s with whatever you want for your base color at emission level '1'
         Color finalColor = baseColor * Mathf.LinearToGammaSpace (emission);
         mat.SetColor ("_EmissionColor", finalColor);
    }

    void Update()
    {
        if(isOpen)
        foreach (var item in materials)
        {
            LightsContral(item);
        }
    }
}

