using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
    //Кнопка Начать
    public void NewGameLoadScenceSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
