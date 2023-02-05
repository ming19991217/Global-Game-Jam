using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ScenesAsset asset;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    public void PlayAddNodeAudio()
    {
        if (Camera.main.TryGetComponent<AudioSource>(out AudioSource source))
        {
            source.PlayOneShot(asset.AddNodeAudio);
        }
    }
    public void PlayOpenDoor()
    {
        if (Camera.main.TryGetComponent<AudioSource>(out AudioSource source))
            source.PlayOneShot(asset.openDoorAudio);
    }
    public void PlayRemoveNodeAudio()
    {
        if (Camera.main.TryGetComponent<AudioSource>(out AudioSource source))
            source.PlayOneShot(asset.AddNodeAudio);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("level");
    }



}
