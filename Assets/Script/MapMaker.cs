using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
    public DataHandler dataHandler;

    // Start is called before the first frame update
    void Start()
    {

        dataHandler = GetComponent<DataHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dataHandler.SaveData(transform.position.x);

        }

    }
}
