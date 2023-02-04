using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button start;
    public Button end;

    private void Awake()
    {

        start.onClick.AddListener(() =>
        {
            start.interactable = false;
            LoadGameScence();
        });

        end.onClick.AddListener(EndGame);
    }

    void LoadGameScence()
    {
        GameManager.Instance.LoadGame();
    }

    void EndGame()
    {
        Application.Quit();
    }

}
