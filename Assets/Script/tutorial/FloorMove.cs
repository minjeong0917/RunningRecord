using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{

    Camera mainCamera;
    private float speed = 4.5f;



    // Start is called before the first frame update
    void Start()
    {

        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
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
                // 오브젝트의 위치를 x축으로 이동
                objectPosition.x = objectPosition.x + 25.0f;
                transform.position = objectPosition;

            }
        }
    }

}
