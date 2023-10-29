using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour
{

    float speed = 4.5f;//3.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = 1.0f;

        h = h * speed * Time.deltaTime;
        transform.Translate(Vector3.right * h);
    }
}
