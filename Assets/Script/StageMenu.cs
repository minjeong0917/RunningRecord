using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StageMenu : MonoBehaviour
{
    //[SerializeField] GameObject TitleMenu = null;


    public void BtnBack()
    {
        /*
        TitleMenu.SetActive(true);
        this.gameObject.SetActive(false);*/
        SceneManager.LoadScene("Start");

    }

    public void BtnPlayStage1()
    {
        // �� ��ư�� ���� �������� 1�� �̵�
        Time.timeScale = 1f;
        LoadingController.LoadScene("Stage1");
        GameManager.instance.isStartGame = true;
        //GameManager.instance.GameStart();


    }

    public void BtnPlayStage2()
    {
        Time.timeScale = 1f;

        //SceneManager.LoadScene("LoadingScene");
        LoadingController.LoadScene("Stage2");

        GameManager.instance.isStartGame = true;

        //GameManager.instance.GameStart();


    }
}
