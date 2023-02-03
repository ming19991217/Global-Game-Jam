using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIswitch : MonoBehaviour
{
    /// <summary>
    /// 開始遊戲按鈕
    /// </summary>
    public Button Sbtn;
    /// <summary>
    /// 離開按鈕
    /// </summary>
    public Button Qbtn;
    // Start is called before the first frame update
    void Start()
    {
        Sbtn.onClick.AddListener(delegate () {

        });

        Qbtn.onClick.AddListener(delegate () {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
