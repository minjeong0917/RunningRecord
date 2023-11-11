using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{

    public void BtnMenu()
    {
        SceneManager.LoadScene("StageChoice");
    }

    public void BtnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재의 Scene 불러오기
    }

    public void BtnNext()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 다음 index의 scene 불러오기 (다음 스테이지 불러오기)
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}
