using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMeteor : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {     
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        if(collision.TryGetComponent<HpBarOfRacket>(out HpBarOfRacket result))
        {
            
            result.GetComponent<HpBarOfRacket>().Hp -= 0.25f;
        }
        StartCoroutine(ParticleDestroy());
    
    }
    
    private IEnumerator ParticleDestroy()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
