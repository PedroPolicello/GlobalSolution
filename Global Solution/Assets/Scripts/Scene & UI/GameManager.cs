using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager instance;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI lifeNumber;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private TextMeshProUGUI totalScoreNumber;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private GameObject gameOverMenu;

    [Header("Scores")]
    private int playerScore = 0;
    private int ongScore = 0;
    private int totalScore = 0;
    private int currentLife;
    private int maxLife = 3;
    private int gameOverScore = 0;

    void Awake()
    {
        instance = this;
        currentLife = maxLife;
        UpdatePlayerLife(currentLife);
    }



    public void PlayerScore()
    {
        playerScore += 5;
        if (playerScore >= 30)
        {
            playerScore = 30;
            print("YOU ARE FULL");
        }
        UpdatePlayerScore(playerScore);
    }

    public void LoseScore()
    {
        playerScore -= 3;
        if (playerScore <= 0)
        {
            playerScore = 0;
        }
        UpdatePlayerScore(playerScore);
    }

    public void GeralScore()
    {
        totalScore = ongScore + playerScore;
        ongScore = totalScore;
        playerScore = 0;
        UpdateTotalScore(totalScore);
        UpdatePlayerScore(playerScore);
    }

    public void PlayerLife()
    {
        currentLife--;
        UpdatePlayerLife(currentLife);

        if (currentLife <= 0)
        {
            gameOverScore = totalScore;
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
            scoreText.gameObject.SetActive(false);
            lifeText.gameObject.SetActive(false);
            lifeNumber.gameObject.SetActive(false);
            totalScoreText.gameObject.SetActive(false);
            totalScoreNumber.gameObject.SetActive(false);

            UpdateGameOverScore(gameOverScore);
        }
    }


    //Updates
    public void UpdatePlayerLife(int currentLife)
    {
        lifeNumber.text = currentLife.ToString();
    }

    public void UpdatePlayerScore(int playerScore)
    {
        scoreText.text = playerScore.ToString();
    }

    public void UpdateTotalScore(int totalScore)
    {
        totalScoreNumber.text = totalScore.ToString();
    }

    public void UpdateGameOverScore(int gameOverScore)
    {
        gameOverScoreText.text = gameOverScore.ToString();
    }
}
