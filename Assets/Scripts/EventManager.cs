using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnSpawnPlanets;
    public static event Action OnStartMove;
    public static event Action OnDestroyShip;
    public static event Action OnUiInfromationPoints;
    public static event Action OnUiInfromationReport;
    public static event Action<float> OnUiInfromationTime;

    public static void SpawnPlanets()
    {
        OnSpawnPlanets?.Invoke();
        OnStartMove?.Invoke();
    }
    public static void DestroyShip()
    {
        OnDestroyShip?.Invoke();
    }
    public static void UiInformation()
    {
        OnUiInfromationPoints?.Invoke();
      
        OnUiInfromationReport?.Invoke();
    }
    public static void UiInformationTime(float time)
    {
        OnUiInfromationTime?.Invoke(time);
    }


}
