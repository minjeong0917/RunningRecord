using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (mainCamera != null)
        {
            // 현재 오브젝트의 위치를 월드 좌표로 얻음
            Vector3 objectPosition = this.transform.position;

            // 오브젝트의 화면 위치를 뷰포트 좌표로 변환
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(objectPosition);
            // 오브젝트가 화면 오른쪽 밖에 있는지 확인 (viewportPosition.x > 1.0는 화면 오른쪽 밖을 의미)
            if (viewportPosition.x < 0.0f)
            {
                // 오브젝트의 위치를 x축으로 25만큼 옮김
                objectPosition.x += 30.0f;

                // 옮긴 위치를 적용
                transform.position = objectPosition;
            }
        }
    }
}
