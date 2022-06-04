using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject _buttonRestart;
    private void Start()
    {
        EventManager.OnDestroyShip += RestartGameMenu;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EventManager.OnDestroyShip -= RestartGameMenu;
            SceneManager.LoadScene("Menu");
        }
    }
    private void RestartGameMenu()
    {
        _buttonRestart.SetActive(true);
    }

    public void Restart()
    {
        EventManager.OnDestroyShip -= RestartGameMenu;
        // _buttonRestart.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
