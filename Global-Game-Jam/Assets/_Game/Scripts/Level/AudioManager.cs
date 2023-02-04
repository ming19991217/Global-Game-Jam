using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Play(AudioClip clip)
    {
        // AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        audioSource.clip = clip;
        audioSource.Play();
        // audioSource.PlayOneShot(clip);
    }

}
