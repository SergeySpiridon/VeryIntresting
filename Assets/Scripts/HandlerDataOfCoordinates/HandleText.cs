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
    // Если строка loop_* содержит 1, то вернет true 
    public bool GetClosureParametr()
    {
        string loop = _data.ClosureParametr;
        return loop.Contains("1");
    }
    public float GetTime()
    {
        return _data.Time;
    }
    //Проверка на корректность строк 
    //Корректные строки - [1,2] [3.23,2.21] [,1] [1,] [,]
    public List<float[]> HandlePoints()
    {
        List<float[]> points = new List<float[]>();
        foreach (var point in _data.ArrayPoints)
        {
            //Если строка пустая
            if (string.IsNullOrWhiteSpace(point))
                continue;
            if (!point.Contains(","))
            {
                Debug.Log("Координаты с неверным форматом");
                continue;
            }
            //если строка состоит только из запятой
            else if (point.Equals(","))
            {
                float[] resultArr = { 0, 0 };
                points.Add(resultArr);
            }
            //Если строка начинается с запятой
            else if (point.StartsWith(","))
            {
                var result = ParseNumber(point.Substring(1, 1));
                if (!result.Item2)
                    continue;
                float[] resultArr = { 0, result.Item1 };
                points.Add(resultArr);
            }
            //если строка заканчивается запятой
            else if(point.EndsWith(","))
            {
                var result = ParseNumber(point.Substring(point.Length-2,1));
                if (!result.Item2)
                    continue;
                float[] resultArr = { result.Item1, 0 };
                points.Add(resultArr);
            }
         
            //строка нормального вида
            else
            {
                string[] arrString = point.Split(',');
                float[] arrFloat = new float[arrString.Length];
                
                //Если координат больше двух.
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
    //проверка на корректность данных
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
