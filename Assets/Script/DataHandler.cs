using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataHandler : MonoBehaviour
{
    public void SaveData(float xValue)
    {
        string filePath = Application.dataPath + "/ThornXPoint.txt";
        float roundedXValue = Mathf.Round(xValue + 3.2f);


        // 데이터를 텍스트 파일에 저장
        File.AppendAllText(filePath, roundedXValue.ToString("F1")+"\n");
    }

    public List<float> LoadData()
    {
        List<float> loadedData = new List<float>();
        string filePath = Application.dataPath + "/ThornXPoint.txt";

        if (File.Exists(filePath))
        {
            // 텍스트 파일에서 데이터를 읽어옴
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (float.TryParse(line, out float xValue))
                {
                    loadedData.Add(xValue);
                }
            }
        }

        return loadedData;
    }
}
