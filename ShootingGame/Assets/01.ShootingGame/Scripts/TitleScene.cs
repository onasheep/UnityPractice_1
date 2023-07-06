using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour
{
    public void OnStartButton()
    {
        GFunc.LoadScene("PlayScene");
    }

    public void OnEndButton()
    {
        Application.Quit();
    }
}
