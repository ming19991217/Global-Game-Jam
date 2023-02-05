using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelManager : MonoBehaviour
{
    public int MaxCount = 1;
    public TMP_Text CountUI;
    public static bool Finish;
    public GameObject winUI;
    static Action WinEvent;

    public static void Win()
    {
        WinEvent?.Invoke();
        Finish = true;
    }

    private void Start()
    {
        LineManager.OnAddNode += UpdateUI;
        LineManager.OnRemoveNode += UpdateUI;
        WinEvent += ShowWinUI;

        CountUI.text = 0 + "/" + MaxCount;
    }

    void ShowWinUI()
    {
        winUI.gameObject.SetActive(true);
    }

    void UpdateUI(int index)
    {

    }







}
