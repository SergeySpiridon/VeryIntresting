using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlanets : MonoBehaviour
{
    [SerializeField]
    private ParsingText _parsingText;
    [SerializeField]
    private List<GameObject> _planets;
    

    private void Start()
    {
        EventManager.OnSpawnPlanets += SpawnPlanets;
        
    }
    //ѕланеты по€вл€ютс€ на координатах
    private void SpawnPlanets()
    {
        for (int i = 0; i < _parsingText.PointsToMove.Count; i++)
        {
            GameObject planet = _planets[Random.Range(0, _planets.Count)];
            var point = _parsingText.PointsToMove[i];
            var pointToMove = new Vector2(point[0], point[1]);
            Instantiate(planet, pointToMove, Quaternion.identity);

        }
        SpawnPlanetsLost();

    }

    private void SpawnPlanetsLost()
    {
        EventManager.OnSpawnPlanets -= SpawnPlanets;
    }
}
