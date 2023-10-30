using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] goGameUI = null;

    public static GameManager instance;

    public bool isStartGame = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void GameStart()
    {
        for( int i = 0; i < goGameUI.Length; i++) // 모두 활성화할때까지 반복
        {
            goGameUI[i].SetActive(true);
        }
        isStartGame = true;
    }

}
