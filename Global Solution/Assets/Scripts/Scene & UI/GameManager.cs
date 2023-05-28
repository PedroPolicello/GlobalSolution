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
    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private TextMeshProUGUI lifeText;

    [Header("Scores")]
    public int playerScore = 0;
    public int ongScore = 0;
    public int totalScore = 0;
    public int currentLife;
    public int maxLife;

    void Awake()
    {
        instance = this;
        currentLife = maxLife;
    }



    public void PlayerScore()
    {
        playerScore += 5;
        UpdateScore();
    }
    public void LoseScore()
    {
        playerScore -= 3;
        UpdateScore();
    }

    public void GeralScore()
    {
        totalScore = ongScore + playerScore;
        ongScore = totalScore;
        playerScore = 0;
        UpdateTotalScore();
    }

    public void PlayerLife()
    {
        currentLife--;

        if (currentLife <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    //Updates
    public void UpdatePlayerLife()
    {
        lifeText.text = currentLife.ToString();
    }

    public void UpdateScore()
    {
        scoreText.text = playerScore.ToString();
    }

    public void UpdateTotalScore()
    {
        totalScoreText.text = totalScore.ToString();
    }
}
