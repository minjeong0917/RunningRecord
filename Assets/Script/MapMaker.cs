using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
    public DataHandler dataHandler;
    private GameObject contactedFloor; // 접촉한 floor 오브젝트를 저장할 변수
    public bool isMakeTrap;
    public bool isMakeMap;
    public bool isMakeItem;
    private Vector3 nowfloor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.parent.name.StartsWith("Floor"))
        {
            contactedFloor = collision.transform.parent.gameObject; // 접촉한 floor 오브젝트를 저장
        }
    }

        

    // Start is called before the first frame update
    void Start()
    {

        dataHandler = GetComponent<DataHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMakeTrap)
        {
            gameObject.layer = 8; 

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                dataHandler.SaveData("ThornXPoint", transform.position.x + 1.0f);

            }
        }

        if (isMakeMap)
        {
            gameObject.layer = 8; 

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (contactedFloor != null)
                {
                    // 접촉한 floor 오브젝트의 위치를 가져옴
                    Vector3 floorPosition = contactedFloor.transform.position;

                    dataHandler.SaveData("UpFloor", floorPosition.x-5.0f);
                }
            
            }
        }
        if (isMakeItem) {
            gameObject.layer = 8; 

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (contactedFloor != null)
                {
                    // 접촉한 floor 오브젝트의 위치를 가져옴
                    Vector3 floorPosition = contactedFloor.transform.position;

                    dataHandler.SaveData("DropItem", transform.position.x);
                }

            }
        }
        
    }
}
