using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldStatus : MonoBehaviour
{
    [SerializeField]
    private GameObject _shield;
    private Renderer _renderer;
    private Collider2D _collider;
    [SerializeField]
    private Image _statusBar;
    private event Action OnShieldStatus;
    public float Health { get; private set; }

    [SerializeField]
    private AudioSource _audioSource;

    void Start()
    {
         Health = 1f;
        _renderer = gameObject.GetComponent<Renderer>();
        _collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
            ShieldActive();
    }
    
    private void ShieldActive()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _statusBar.fillAmount -= 0.02f;
            if (_statusBar.fillAmount > 0.1f)
            {
                _audioSource.Play();
                _renderer.enabled = true;
                _collider.enabled = true;
            }
            else
            {
                _renderer.enabled = false;
                _collider.enabled = false;
            }
        }
        else
        {
            _renderer.enabled = false;
            _collider.enabled = false;
            _statusBar.fillAmount += 0.01f;
        }
    }
}
