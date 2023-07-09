using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverUi = default;
    public GameObject timeText = default;
    public GameObject recordText = default;
    
    private float surviveTime = default;

    private bool isGameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        surviveTime = 0f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {

            surviveTime += Time.deltaTime;

            timeText.SetText(string.Format("동물들에게 {0}초 버티는 중!", (int)surviveTime));
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GFunc.LoadScene("TitleScene");
            }
        }

        if (Input.GetKey(KeyCode.Escape) && isGameOver)
        {
            Application.Quit();
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        
        GameOverUi.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");


        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }




        recordText.SetText(string.Format("최고 기록 : {0}", (int)bestTime));

        Time.timeScale = 0.3f;

    }
}
