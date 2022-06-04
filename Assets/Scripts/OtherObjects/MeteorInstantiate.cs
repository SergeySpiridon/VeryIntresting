using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorInstantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject _meteor;
    [SerializeField]
    private float _minSize;
    [SerializeField]
    private float _maxSize;
    [SerializeField]
    private float _minSpeed;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _minY;
    [SerializeField]
    private float _maxY;
    [SerializeField]
    private float _frequency;

    void Start()
    {
        InvokeRepeating(nameof(CreateObjects), 0, _frequency);

    }

    private void CreateObjects()
    {
        GameObject meteor = _meteor;
        Vector2 pos = new Vector2(transform.position.x - 20, transform.position.y + Random.Range(_minY, _maxY)); ;
        float scl = Random.Range(_minSize, _maxSize);
        Vector2 scale = new Vector2(scl, scl);
        float speed = Random.Range(_minSpeed, _maxSpeed);
        GameObject m = Instantiate(meteor, pos, Quaternion.identity);
        m.GetComponent<MoveObjects>().Speed = speed;
        m.transform.localScale = scale;
        m.transform.rotation = Quaternion.Euler(0, 0, 90);
        StartCoroutine(DestroyObject(m));
    }
    
    private IEnumerator DestroyObject(GameObject obj)
    {
        yield return new WaitForSeconds(10);
        Destroy(obj);
    }
}
