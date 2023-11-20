using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public GameObject GameoverPopup = null;
    public GameObject FinishPopup = null;
    public GameObject PausePopup = null;
    [SerializeField] Text txtProgress = null;
    [SerializeField] Image progressBar;

    Progress theProgress;

    // Start is called before the first frame update
    void Start()
    {
        GameoverPopup.SetActive(false);
        FinishPopup.SetActive(false);
        PausePopup.SetActive(false);
        GameManager.instance.isStartGame = true;
        theProgress = FindObjectOfType<Progress>();        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    void Pause()
    {
        PausePopup.SetActive(!PausePopup.activeSelf);

        if (PausePopup.activeSelf)
        {
            Time.timeScale = 0f; // 이게 1이면 움직임...!
            //AudioManager.instance.StopBGM();

        }
        else
        {
            Time.timeScale = 1f;
            // AudioManager.instance.ResumeBGM();

        }
    }

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
