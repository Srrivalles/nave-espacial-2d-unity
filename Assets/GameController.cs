using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;



public class GameController : MonoBehaviour
{

    public static GameController instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverScreen;
    private int score;
    private int highScore;


    void Start()
    {
        instance = this;
        if (PlayerPrefs.HasKey("Score"))
        {
            highScore = PlayerPrefs.GetInt("Score");
        }

        highScoreText.text = "HighScore:" + highScore;
        UpdateScore(0);

    }
    public void UpdateScore(int points)
    {

        score += points;
        scoreText.text = "Score:" + score;

    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("Score",score);
            highScoreText.text = "HighScore:" + highScore;
        }

    }
    public void Restart() {

        SceneManager.LoadScene(0);
    }

}
