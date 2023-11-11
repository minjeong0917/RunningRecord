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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ������ Scene �ҷ�����
    }

    public void BtnNext()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ���� index�� scene �ҷ����� (���� �������� �ҷ�����)
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}
