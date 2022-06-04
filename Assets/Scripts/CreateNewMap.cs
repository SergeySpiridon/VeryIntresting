using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewMap : MonoBehaviour
{
    [SerializeField]
    private Collider2D _ship;
    [SerializeField]
    private GameObject _maps;
    [SerializeField]
    private List<Transform> _pointsForCreateMaps;
    [SerializeField]
    private Collider2D _mapCollider;
    private void Start()
    {
        _mapCollider = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "TriggerMap")
        {
            Debug.Log("SAS");
            Destroy(_mapCollider);
            foreach (var point in _pointsForCreateMaps)
            {
                Transform pointCreate = point.transform;
                Debug.Log(pointCreate.transform.position);
               Instantiate(_maps, pointCreate);
            }
        }
    }
   
}
