using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public GameObject GameoverPopup = null;

    // Start is called before the first frame update
    void Start()
    {
        GameoverPopup.SetActive(false);
    }

    // Update is called once per frame
    public void Gameover()
    {
        GameoverPopup.SetActive(true);
    }
}
