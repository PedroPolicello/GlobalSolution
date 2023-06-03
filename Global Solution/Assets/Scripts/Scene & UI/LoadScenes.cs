using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    [SerializeField] private AudioSource buttonClick;

    public void StartGame()
    {
        buttonClick.Play();
        SceneManager.LoadScene("Gameplay");
    }

    public void ExitGame()
    {
        buttonClick.Play();
        Application.Quit();
    }

    public void MainMenu()
    {
        buttonClick.Play();
        SceneManager.LoadScene("MenuInicial");
    }
}
