using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tip : MonoBehaviour
{
    //public Text textDisplay;
    public TMP_Text textDisplay;

    private string[] randomTexts;

    void Start()
    {
        // ���� �õ� ����
        Random.InitState((int)System.DateTime.Now.Ticks);

        // �ؽ�Ʈ �迭�� ������ ������ �������ּ���.
        randomTexts = new string[]
        {
        "TIP. ���� �˾� â�� ���� ���� �������� �ְ� ���൵�� �� �� �ֽ��ϴ�.",
        "TIP. ���� ������ �˾�â������ ���� �������� ���൵�� ǥ���մϴ�.",
        "TIP. �������� �� ������ CD�� ���� ���ٴ°� �˰� �ֳ���?",
            // �ʿ��� ��ŭ ��� �߰��� �� �ֽ��ϴ�.
        };

        // ���� �ؽ�Ʈ ��� �Լ� ȣ��
        DisplayRandomText();
    }


    void DisplayRandomText()
    {
        // ������ �ε��� ����
        int randomIndex = Random.Range(0, randomTexts.Length);

        // ���õ� �ε����� �ؽ�Ʈ�� ȭ�鿡 ǥ��
        textDisplay.text = randomTexts[randomIndex];
    }

}
