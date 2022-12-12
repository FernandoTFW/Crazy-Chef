using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusManager : MonoBehaviour
{
    public void StartGame()
    {
        Scoring.score = 0;
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        Scoring.score = 0;
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();

    }
}
