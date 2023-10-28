using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Background : MonoBehaviour
{
    public Camera mainCamera;
    float repeat;
    private Transform[] backgroundTile; 
    private int currentIndex = 0;
    void Start()
    {
        repeat = 1;
        backgroundTile = transform.GetComponentsInChildren<Transform>().Where(child => child.name == "Tilemap").ToArray();// 그리드의 Tilemap 리스트
    }

    // Update is called once per frame
    void Update()
    {
        float camPosition = mainCamera.gameObject.transform.position.x + 3;
        if (camPosition - 48*repeat > 0)
        {//카메라의 위치가 하나의 타일 맵을 지나면 해당 타일맵을 다음 타일맵의 뒤로 이동
            repeat += 1;
            backgroundTile[currentIndex].transform.Translate(96,0,0);
            currentIndex = (currentIndex + 1)%2;
            
        }

        
    }
}
