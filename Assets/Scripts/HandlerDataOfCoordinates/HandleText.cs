using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleText
{
    private JsonForm _data;
    public HandleText(JsonForm data)
    {
        _data = data;
    }
    // ���� ������ loop_* �������� 1, �� ������ true 
    public bool GetClosureParametr()
    {
        string loop = _data.ClosureParametr;
        return loop.Contains("1");
    }
    public float GetTime()
    {
        return _data.Time;
    }
    //�������� �� ������������ ����� 
    //���������� ������ - [1,2] [3.23,2.21] [,1] [1,] [,]
    public List<float[]> HandlePoints()
    {
        List<float[]> points = new List<float[]>();
        foreach (var point in _data.ArrayPoints)
        {
            //���� ������ ������
            if (string.IsNullOrWhiteSpace(point))
                continue;
            if (!point.Contains(","))
            {
                Debug.Log("���������� � �������� ��������");
                continue;
            }
            //���� ������ ������� ������ �� �������
            else if (point.Equals(","))
            {
                float[] resultArr = { 0, 0 };
                points.Add(resultArr);
            }
            //���� ������ ���������� � �������
            else if (point.StartsWith(","))
            {
                var result = ParseNumber(point.Substring(1, 1));
                if (!result.Item2)
                    continue;
                float[] resultArr = { 0, result.Item1 };
                points.Add(resultArr);
            }
            //���� ������ ������������� �������
            else if(point.EndsWith(","))
            {
                var result = ParseNumber(point.Substring(point.Length-2,1));
                if (!result.Item2)
                    continue;
                float[] resultArr = { result.Item1, 0 };
                points.Add(resultArr);
            }
         
            //������ ����������� ����
            else
            {
                string[] arrString = point.Split(',');
                float[] arrFloat = new float[arrString.Length];
                
                //���� ��������� ������ ����.
                if (arrString.Length > 2)
                    continue;
      
                for (int i = 0; i < arrString.Length; i++)
                {
                    var result = ParseNumber(arrString[i]);
                    if (!result.Item2)
                        continue;
                    arrFloat[i] = result.Item1;
                }
                points.Add(arrFloat);
            }
        }
        return points;
    }
    //�������� �� ������������ ������
    private Tuple<float,bool> ParseNumber(string number)
    {
        bool tryParse = float.TryParse(number, out var result);
        bool resultBool = true;
        if (!tryParse)
        {
            EventManager.UiInformation();
           resultBool = false;
        }
        Tuple<float, bool> resultMethod = new Tuple<float, bool>(result, resultBool);
        return resultMethod;
    }
}
