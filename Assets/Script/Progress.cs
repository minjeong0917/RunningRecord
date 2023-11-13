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


    private bool isGameProgress = true; // ������ ���� �������� ��Ÿ��


    void Update()
    {
        if (isGameProgress) // ������ ���� ���� ���� ���൵�� ������Ʈ
        {
            currentValue += speed * Time.deltaTime;

            if (currentValue < 100) // ���൵�� 100 ������ ��
            {
                progresstext.text = ((int)currentValue).ToString() + "%";
            }
            else
            {
                currentValue = 100;
                progresstext.text = "100%!";
                isGameProgress = false;
            }

            frontprogress.fillAmount = currentValue / 100;  // ���൵�� ���� ���൵ �ٸ� ä��
        }
    }

    public void GameOver()
    {
        isGameProgress = false; // ������ ����Ǿ����� ǥ��
    }

}
