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


       // # �̵�
       float h = 1.0f;
       float v = Input.GetAxis("Vertical");

        // �̵� �Ÿ� ���� - ���ɿ� ���� �� �����ӿ� ������ ��� �� ����
        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;

        // ���� �̵�
        transform.Translate(Vector3.right * h);
        transform.Translate(Vector3.forward * v);


    }
}
