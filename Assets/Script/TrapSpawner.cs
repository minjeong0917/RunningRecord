using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    Camera mainCamera;
    public GameObject trapPrefab; // 프리팹을 인스펙터에서 할당해야 합니다.
    public Vector3 spawnPosition; // 생성할 위치를 인스펙터에서 설정해야 합니다.
    public PlayerMove movescript;
    private List<float> xCoordinates = new List<float>(); // 100개의 float 값을 저장하는 리스트
    public DataHandler dataHandler;

    // Start is called before the first frame update
    void Start()
    {
        xCoordinates = dataHandler.LoadData();
        for (int i = 0; i < xCoordinates.Count; i++)
        {
            TrapGenerate(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void TrapGenerate(int i)
    {
        spawnPosition = new Vector3(xCoordinates[i], -2.6f, 0.0f);
        GameObject newTrap = Instantiate(trapPrefab, spawnPosition, Quaternion.identity);

        /*GameObject newTrap = Instantiate(trapPrefab);
        if (trapsParent != null)
        {
            newTrap.transform.parent = trapsParent.transform;
            newTrap.transform.position = spawnPosition;
        }*/

    }
    void TrapDestroy()
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
