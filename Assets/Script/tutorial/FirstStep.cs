using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStep : MonoBehaviour
{
    public Camera mainCamera;
    public float speed;
    public float delay;
    float alpha = 1f;
    float fadeTime = 0.5f;
    //스텝1: 장애물 하나를 뛰어넘기

    void Update()
    {
        //곡 반복재생 관련 코드

        //장애물 이동 코드
        float h = -1.0f;

        h = h * speed * Time.deltaTime;
        transform.Translate(Vector3.right * h);


        if (mainCamera != null)
        {
            Vector3 objectPosition = this.transform.position;
            Vector3 rightEndPosition = transform.position + transform.right * (transform.localScale.x / 2);

            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.2f, 0.5f, 0));
            
            
            if (rightEndPosition.x < leftEdge.x)
            {
                
                objectPosition.x = objectPosition.x + delay;
                transform.position = objectPosition;

            }
        }
    }
}