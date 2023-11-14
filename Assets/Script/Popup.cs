using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public GameObject GameoverPopup = null;
    public GameObject FinishPopup = null;
    [SerializeField] Text txtProgress = null;
    [SerializeField] Image progressBar;

    Progress theProgress;

    // Start is called before the first frame update
    void Start()
    {
        FinishPopup.SetActive(false);
        GameoverPopup.SetActive(false);
        GameManager.instance.isStartGame = true;
        theProgress = FindObjectOfType<Progress>();        

    }

    // Update is called once per frame
    public void Gameover()
    {
        GameoverPopup.SetActive(true);
        AudioManager.instance.StopBGM();
        AudioManager.instance.PlaySFX("fail");
        GameManager.instance.isStartGame = false;
        ShowProgress();

    }

    public void GameSuccess()
    {
        FinishPopup.SetActive(true);
        AudioManager.instance.PlaySFX("Success");
        GameManager.instance.isStartGame = false;


    }

    public void ShowProgress()
    {
        txtProgress.text = "0";

        float t_currentProgress = theProgress.GetCurrentValue();

        progressBar.fillAmount = t_currentProgress / 100.0f;

        txtProgress.text = string.Format("{0:#,##0}%", t_currentProgress);

    }
}
