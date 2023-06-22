using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private int highscore = 0;
    public int playerScore = 0;
    public Text scoreText;
    public Text highscoreText;
    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    void Start()
    {
        Cursor.visible = false;
        playerScore = 0;
        gameOverScreen.SetActive(false);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (!gameOverScreen.activeSelf) 
        {
            highscore = PlayerPrefs.GetInt("Highscore", 0);

            // Zapisz HighScore w PlayerPrefs
            if (playerScore > highscore)
            {
                highscore = playerScore;
                PlayerPrefs.SetInt("Highscore", highscore);
                PlayerPrefs.Save();
                highscoreText.text = "New Highscore: " + highscore.ToString() + "!";
            }
            else
            {
                highscoreText.text = "Highscore: " + highscore.ToString();
            }
            Cursor.visible = true;
            gameOverScreen.SetActive(true);
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
