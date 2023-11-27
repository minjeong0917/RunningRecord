using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{

    public void BtnMenu()
    {
        SceneManager.LoadScene("StageChoice");  // ???????? ?????? Scene ????????
        GameManager.instance.isStartGame = false;
    }

    public void BtnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ?????? Scene ????????
    }

    public void BtnNext()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ???? index?? scene ???????? (???? ???????? ????????)
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void BtnResume()
    {
        Time.timeScale = 1f;
        AudioManager.instance.ResumeBGM();
    }


    public void BtnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void BtnTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
