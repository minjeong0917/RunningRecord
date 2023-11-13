using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public GameObject GameoverPopup = null;
    public GameObject FinishPopup = null;


    // Start is called before the first frame update
    void Start()
    {
        FinishPopup.SetActive(false);
        GameoverPopup.SetActive(false);
        GameManager.instance.isStartGame = true;

    }

    // Update is called once per frame
    public void Gameover()
    {
        GameoverPopup.SetActive(true);
        AudioManager.instance.StopBGM();
        AudioManager.instance.PlaySFX("fail");
        GameManager.instance.isStartGame = false;
    }

    public void GameSuccess()
    {
        FinishPopup.SetActive(true);
        AudioManager.instance.PlaySFX("Success");
        GameManager.instance.isStartGame = false;


    }
}
