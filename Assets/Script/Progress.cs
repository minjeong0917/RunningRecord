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

            if (currentValue < 99)   // ?????? ???? ???????? ???????? ??????
            {
                progresstext.text = ((int)currentValue).ToString() + "%";
            }
            else
            {
                progresstext.text = "100%";
                isGameProgress = false;
                Finish();
            }

            frontprogress.fillAmount = currentValue / 100;  // ???????? ???? ?????? ???? ????
        }
    }

    public void GameOver()
    {
        if (currentValue > dataHandler.LoadData("BestProgress")[0])
            dataHandler.ChangeData("BestProgress", currentValue);
            isGameProgress = false;
    }
    public void Finish()
    {
        dataHandler.ChangeData("BestProgress", 100);
        isGameProgress = false;
    }

    public float GetCurrentValue()
    {
        return currentValue;
    }

}
