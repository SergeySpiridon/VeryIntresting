using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;

public class ParsingText : MonoBehaviour
{
    private JsonForm _jsonLink = new JsonForm();
    public List<float[]> PointsToMove { get; private set; }
    public float Time { get; private set; }
    public bool ClosureParametr { get; private set; }
    private string _path;
    private bool flagSendData = false;
    private string _filePath;
    private void Awake()
    {
        _path = @"%USERPROFILE%\AppData\Local\Data.json";
        _filePath = Environment.ExpandEnvironmentVariables(_path);

            AsyncGetData();

    }
    private void Update()
    {
        //�������, ��� ����� �� �������� ������� ������� � ����������� �������
        if (flagSendData)
        {
            EventManager.SpawnPlanets();
            flagSendData = false;
        }
    }
    //�������������� ������ �� �����
    private void DeserializeText()
    {
       ;
        //���� ����� ��� �� �����, �� ���� �������� � ���� ����� � ����������� �������
        if (!File.Exists(_filePath))
        {
            WebClient client = new WebClient();
            Debug.Log("asas");
            client.DownloadFile("https://drive.google.com/uc?export=download&id=1nFtuL4lXgq8D3mFUgvvSwmHw-4YUj4BM", _filePath);
        }
       
        var jsonParse = File.ReadAllText(_filePath);
        _jsonLink = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonForm>(jsonParse);
        var handleText = new HandleText(_jsonLink);
       
        //�������������� ���������
        PointsToMove = handleText.HandlePoints();
        Time = handleText.GetTime();
        ClosureParametr = handleText.GetClosureParametr();
        flagSendData = true;
  
        
}
    //����������� ��������� � ������
    private async Task AsyncGetData()
    {
        Debug.Log("Start");
        await Task.Run(() => DeserializeText());
        Debug.Log("End");
    }
}
