using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    Camera mainCamera;
    public GameObject trapPrefab; // 프리팹을 인스펙터에서 할당해야 합니다.
    private Vector3 spawnPosition; // 생성할 위치를 인스펙터에서 설정해야 합니다.
    private List<float> TrapSpawnX = new List<float>();
    public DataHandler dataHandler;
    private List<float> upFloorX = new List<float>();
    private float FloorY;
    private List<float> DropItem = new List<float>();
    public GameObject ItemPrefab;
    private float floorBasePosition;
    void Start()
    {
        TrapSpawnX = dataHandler.LoadData("ThornXPoint");
        upFloorX = dataHandler.LoadData("UpFloor");
        DropItem = dataHandler.LoadData("DropItem");
        floorBasePosition = GameObject.Find("AllFloorObj").transform.position.x;
        FloorY = GameObject.Find("Floor").transform.position.y + GameObject.Find("AllFloorObj").transform.position.y +0.1f;
        for (int i = 0; i < TrapSpawnX.Count; i++)
        {
            TrapGenerate(i);
        }
        for (int i = 0; i < DropItem.Count; i++)
            ItemGenerate(i);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void TrapGenerate(int i)
    {
        spawnPosition = new Vector3(TrapSpawnX[i], FloorY, 0.0f);

        for(int j=0;j<upFloorX.Count; j++)
        {
            if ((TrapSpawnX[i] > upFloorX[j]-floorBasePosition/2-1.5f) && (TrapSpawnX[i] < upFloorX[j] - floorBasePosition/2 + 3.5f))
            {
                spawnPosition.y += 1;
                Debug.Log("x:" + TrapSpawnX[i] + "floorx:" + upFloorX[j]);
            }
        }
        GameObject newTrap = Instantiate(trapPrefab, spawnPosition, Quaternion.identity);
        newTrap.transform.parent = this.transform;


    }
    void ItemGenerate(int i)
    {
        spawnPosition = new Vector3(DropItem[i], FloorY+1.1f, 0.0f);

        for (int j = 0; j < upFloorX.Count; j++)
        {
            if ((DropItem[i] > upFloorX[j] - floorBasePosition / 2 - 1.5f) && (DropItem[i] < upFloorX[j] - floorBasePosition / 2 + 3.5f))
            {
                spawnPosition.y += 1;
                Debug.Log("x:" + TrapSpawnX[i] + "floorx:" + upFloorX[j]);
            }
        }
        GameObject newItem = Instantiate(ItemPrefab, spawnPosition, Quaternion.identity);
        newItem.transform.parent = this.transform;


    }

}
