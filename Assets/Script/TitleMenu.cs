using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleMenu : MonoBehaviour
{

    //[SerializeField] GameObject goStageUI = null;

    public void BtnPlay()
    {
        SceneManager.LoadScene("StageChoice");
        /*
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false); // ����ȭ�� ��Ȱ��ȭ*/

    }
}
