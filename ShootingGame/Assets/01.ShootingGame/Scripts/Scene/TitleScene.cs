using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void OnStartButton()
    {
        GFunc.LoadScene("PlayScene");
    }

    public void OnEndButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
