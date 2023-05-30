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
    private int playerScore = 0;
    private int ongScore = 0;
    private int totalScore = 0;
    private int currentLife;
    private int maxLife = 3;

    void Awake()
    {
        instance = this;
        currentLife = maxLife;
        UpdatePlayerLife();
    }



    public void PlayerScore()
    {
        playerScore += 5;
        UpdateScore();
    }

    public void LoseScore()
    {
        playerScore -= 3;
        if(playerScore <=0)
        {
            playerScore = 0;
        }
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
        UpdatePlayerLife();
        
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
