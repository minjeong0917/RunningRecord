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
        if(PlayerPrefs.HasKey("Tutorial")==false) {
            {
                PlayerPrefs.SetInt ("Tutorial", 0);
                PlayerPrefs.Save ();
            }
		}

    }

    public void BtnPlay()
    {

        if (PlayerPrefs.GetInt("Tutorial")==0)
        {
            PlayerPrefs.SetInt("Tutorial", 1);
            PlayerPrefs.Save();
            TutorialPopup.SetActive(true);
        }else if(PlayerPrefs.GetInt("Tutorial") == 1) {
            SceneManager.LoadScene ("StageChoice");
        }


        /*
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false); // ???????? ????????*/

    }

}
