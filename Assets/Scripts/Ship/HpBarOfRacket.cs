using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarOfRacket : MonoBehaviour
{
    public float Hp { get; set; }
    [SerializeField]
    private Image _hpBar;
    private void Start()
    {
        Hp = 1f;
    }
    private void Update()
    {
        _hpBar.fillAmount = Hp;
        if(_hpBar.fillAmount <= 0)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            EventManager.DestroyShip();
            StartCoroutine(ParticleDestroy());
            
        }
    }
    private IEnumerator ParticleDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
