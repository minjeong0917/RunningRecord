using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataHandler : MonoBehaviour
{
    public void SaveData(string Filename, float xValue)
    {
        Debug.Log("/" + Filename + ".txt");
        string filePath = Application.streamingAssetsPath + "/Stages/"+SceneManager.GetActiveScene().name+"/"+Filename+".txt";
        


        // 데이터를 텍스트 파일에 저장
        File.AppendAllText(filePath, xValue.ToString("F1")+"\n");
    }
    public void ChangeData(string Filename, float Value)
    {
        string filePath = Application.streamingAssetsPath + "/Stages/" + SceneManager.GetActiveScene().name + "/" + Filename + ".txt";

        File.WriteAllText(filePath, Value.ToString() + "\n");

        Debug.Log("saveBestProgress");
    }

    public List<float> LoadData(string Filename)
    {
        List<float> loadedData = new List<float>();
        string filePath = Application.streamingAssetsPath + "/Stages/" + SceneManager.GetActiveScene().name + "/" + Filename + ".txt";

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
    public List<float> LoadData_stage(string stage, string Filename)
    {
        List<float> loadedData = new List<float>();
        string filePath = Application.streamingAssetsPath + "/Stages/" + stage + "/" + Filename + ".txt";

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
