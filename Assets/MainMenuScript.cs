using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuiqGame()
    {
        Application.Quit();
    }
}
