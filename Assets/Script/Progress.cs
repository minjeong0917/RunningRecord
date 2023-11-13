using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public Text progresstext;
    public Image frontprogress;
    float currentValue;
    public float speed;


    private bool isGameProgress = true; // 게임이 진행 중인지를 나타냄


    void Update()
    {
        if (isGameProgress) // 게임이 진행 중일 때만 진행도를 업데이트
        {
            currentValue += speed * Time.deltaTime;

            if (currentValue < 100) // 진행도가 100 이하일 때
            {
                progresstext.text = ((int)currentValue).ToString() + "%";
            }
            else
            {
                currentValue = 100;
                progresstext.text = "100%!";
                isGameProgress = false;
            }

            frontprogress.fillAmount = currentValue / 100;  // 진행도에 따라 진행도 바를 채움
        }
    }

    public void GameOver()
    {
        isGameProgress = false; // 게임이 종료되었음을 표시
    }

}
