using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAudio : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isHovered = false; // �ʱ⿡�� ��ư�� ȣ������ ���� ����

    void Start()
    {
        AudioManager.instance.StopSFX("Start"); // ���� ���� �� �Ҹ��� ����
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isHovered) // isHovered�� false�� ������ �Ҹ� ���
        {
            isHovered = true; // ��ư ���� ȣ���Ǿ��� �� true�� ����
            AudioManager.instance.PlaySFX("Start");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false; // ��ư���� ������ �� false�� ����
        // ���⼭ ���Ѵٸ� AudioManager.instance.StopSFX("Space"); ������ �Ҹ��� ������ų ���� �ֽ��ϴ�.
    }
}
