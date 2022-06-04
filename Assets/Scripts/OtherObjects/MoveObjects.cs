using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public float Speed { get; set; }
    [SerializeField]
    private Vector2 _dir;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(_dir * Time.deltaTime * Speed);
    }
}
