using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveToPoints : MonoBehaviour
{
    private float _speedRotation = 2f;

    [SerializeField]
    private ParsingText _parsingText;
    private bool flagMove = false;

    private int index = 0;
    private float counter = 0;
    void Start()
    {
        EventManager.OnStartMove += StartMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (flagMove)
            MovePoint();
    }
    //ѕередвижение по координатам
    private void MovePoint()
    {
        var pointMove = _parsingText.PointsToMove[index];
        var vector3Move = new Vector3(pointMove[0], pointMove[1], 0);
        var distanttsToPoint = Vector3.Distance(transform.position, vector3Move);
        //MoveTowards и Lerp замедл€ют движение при сильном сближении. ќкругление происходит при 0.501, что дает минимальную погрешность во времени
        if (Math.Round(distanttsToPoint, 0) != 0)
        {
            transform.up = vector3Move - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, vector3Move, GetTimeToFinishPoint(pointMove[0], pointMove[1]));

        }
        else
        {

            if (index < _parsingText.PointsToMove.Count - 2)
            {
                EventManager.UiInformation();
                index++;
            }
            //≈сли loop_1, то начинаем с начальной точки
            else
            {
                if (_parsingText.ClosureParametr)
                    index = 0;
            }

            
        }      
    }
    private float GetTimeToFinishPoint(float pointX, float pointY)
    {
        
        counter =+ Time.deltaTime;
        //‘ормула дл€ форматировани€ времени дл€ прохождени€ всей дистанции
        float time = Vector3.Distance(transform.position, new Vector2(pointX, pointY))
            / ((_parsingText.Time / (_parsingText.PointsToMove.Count * 2)) - counter)
            * Time.deltaTime;
        EventManager.UiInformationTime(time);
        return time;

    
    }
    private void StartMove()
    {
        flagMove = true;
    }

}
