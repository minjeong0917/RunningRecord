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
    public DataHandler dataHandler;

    private bool isGameProgress = true;

    void Update()
    {
        if (isGameProgress)
        {
            currentValue += speed * Time.deltaTime;

            if (currentValue < 100)   // 시간에 따른 진행도의 퍼센트를 나타냄
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
        if (currentValue > dataHandler.LoadData("BestProgress")[0])
            dataHandler.ChangeData("BestProgress", currentValue);
        isGameProgress = false;
    }

    public float GetCurrentValue()
    {
        return currentValue;
    }

}
