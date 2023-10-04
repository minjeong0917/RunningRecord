using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 3.0f;


    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


       // # 이동
       float h = 1.0f;
       float v = Input.GetAxis("Vertical");

        // 이동 거리 보정 - 성능에 따라 한 프레임에 나오는 결과 값 보정
        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;

        // 실제 이동
        transform.Translate(Vector3.right * h);
        transform.Translate(Vector3.forward * v);


    }
}
