using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BestProgress : MonoBehaviour
{

    public DataHandler dataHandler;
    public TextMeshProUGUI tmp;
    float bestvalue;

    private void Start()
    {
        bestvalue = dataHandler.LoadData_stage(this.name, "BestProgress")[0];
        if (bestvalue != 0)
        {
            tmp.text = bestvalue.ToString()+"%";
        }
        else
        {
            tmp.text = "00%";
        }
    }


}
