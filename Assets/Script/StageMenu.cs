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

    public void BtnPlay()
    {

        GameManager.instance.GameStart();


        //this.gameObject.SetActive(false);
    }
}
