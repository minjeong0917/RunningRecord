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
        // 랜덤 시드 설정
        Random.InitState((int)System.DateTime.Now.Ticks);

        // 텍스트 배열에 적절한 값들을 설정해주세요.
        randomTexts = new string[]
        {
        "TIP. 정지 팝업 창을 통해 현재 스테이지 최고 진행도를 알 수 있습니다.",
        "TIP. 게임 오버시 팝업창에서는 현재 스테이지 진행도를 표시합니다.",
        "TIP. 라이프가 달 때마다 CD에 금이 간다는걸 알고 있나요?",
            // 필요한 만큼 계속 추가할 수 있습니다.
        };

        // 랜덤 텍스트 출력 함수 호출
        DisplayRandomText();
    }


    void DisplayRandomText()
    {
        // 랜덤한 인덱스 선택
        int randomIndex = Random.Range(0, randomTexts.Length);

        // 선택된 인덱스의 텍스트를 화면에 표시
        textDisplay.text = randomTexts[randomIndex];
    }

}
