using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAudio : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isHovered = false; // 초기에는 버튼에 호버되지 않은 상태

    void Start()
    {
        AudioManager.instance.StopSFX("Start"); // 게임 시작 시 소리를 중지
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isHovered) // isHovered가 false일 때에만 소리 재생
        {
            isHovered = true; // 버튼 위에 호버되었을 때 true로 설정
            AudioManager.instance.PlaySFX("Start");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false; // 버튼에서 나갔을 때 false로 설정
        // 여기서 원한다면 AudioManager.instance.StopSFX("Space"); 등으로 소리를 중지시킬 수도 있습니다.
    }
}
