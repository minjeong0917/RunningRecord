using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public Text progresstext;
    public Image frontprogress;
    float currentValue;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue < 100)
        {
            currentValue += speed * Time.deltaTime;
            progresstext.text = ((int)currentValue).ToString() + "%";
        }
        else
        {
            progresstext.text = "100%";
        }

        frontprogress.fillAmount = currentValue / 100;

    }

}
