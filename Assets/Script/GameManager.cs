using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] GameObject[] goGameUI = null;

    public static GameManager instance;
    public bool isStartGame = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void GameStart()
    {
        LoadingController.LoadScene("Stage1");
        /*
        for( int i = 0; i < goGameUI.Length; i++) // ��� Ȱ��ȭ�Ҷ����� �ݺ�
        {
            goGameUI[i].SetActive(true);
        }*/
        isStartGame = true;
    }

}
