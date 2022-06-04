using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiate : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _stars;
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
            GameObject star = _stars[Random.Range(0, _stars.Count)];
            Vector2 pos = new Vector2(transform.position.x - 20f, transform.position.y + Random.Range(_minY, _maxY));;
            float scl = Random.Range(_minSize, _maxSize);
            Vector2 scale = new Vector2(scl, scl);
            float speed = Random.Range(_minSpeed, _maxSpeed);
            GameObject s = Instantiate(star, pos, Quaternion.identity);
            s.GetComponent<MoveObjects>().Speed = speed;
            s.transform.localScale = scale;
            StartCoroutine(DestroyObject(s));
    }

    private IEnumerator DestroyObject(GameObject obj)
    {
        yield return new WaitForSeconds(10);
        Destroy(obj);
    }
}
