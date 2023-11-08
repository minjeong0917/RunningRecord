using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    Camera mainCamera;

    private List<float> Xfloor = new List<float>();
    public DataHandler dataHandler;
    private bool needReturn = false;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        Xfloor = dataHandler.LoadData("UpFloor");
        
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
            // 오브젝트가 화면 왼쪽 밖에 있는지 확인
            if (viewportPosition.x < 0.0f)
            {
                // 오브젝트의 위치를 x축으로 이Mathf.Approximately(
                objectPosition.x = Mathf.Round(objectPosition.x * 10)*0.1f + 30.0f;
                if (needReturn)
                    objectPosition.y = GameObject.Find("Floor").transform.position.y;
                for (int i=0; i < Xfloor.Count;i++) {
                    if(Xfloor[i] == objectPosition.x)
                    {
                        objectPosition.y += 1.0f;
                        needReturn = true;
                    }
                }
                // 옮긴 위치를 적용
                transform.position = objectPosition;
                
            }
        }
    }
}
