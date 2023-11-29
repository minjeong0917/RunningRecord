using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleMenu : MonoBehaviour
{

    public GameObject TutorialPopup;
    //[SerializeField] GameObject goStageUI = null;
    private void Start()
    {
        TutorialPopup.SetActive(false);
        //PlayerPrefs.SetInt("needTutorial", 0);
        //PlayerPrefs.Save();
    }

    public void BtnPlay()
    {

        if (PlayerPrefs.GetInt("needTutorial")==0)
        {

            PlayerPrefs.SetInt("needTutorial", 1);
            PlayerPrefs.Save();
            TutorialPopup.SetActive(true);
        }else if(PlayerPrefs.GetInt("needTutorial") == 1)
            SceneManager.LoadScene("StageChoice");

        /*
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false); // ???????? ????????*/

    }

}
