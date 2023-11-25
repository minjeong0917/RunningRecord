using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleMenu : MonoBehaviour
{

    //[SerializeField] GameObject goStageUI = null;

    public void BtnPlay()
    {
        PlayerPrefs.SetInt("needTutorial", 0);//?? ??? ???????

        if (PlayerPrefs.GetInt("needTutorial")==0)
        {

            PlayerPrefs.SetInt("needTutorial", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Tutorial");
        }else if(PlayerPrefs.GetInt("needTutorial") == 1)
            SceneManager.LoadScene("StageChoice");

        /*
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false); // ???????? ????????*/

    }

}
