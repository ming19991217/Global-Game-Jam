using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{

    public GameObject _camera;
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError(other.tag);
        if (other.CompareTag("Player"))
        {
            _camera.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.LogError(other.tag);
        if (other.CompareTag("Player"))
        {
            _camera.SetActive(false);
        }
    }
}
