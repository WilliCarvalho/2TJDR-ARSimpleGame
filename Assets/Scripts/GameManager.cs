using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Image[] heartImages;
    [SerializeField] private Transform gameOverContainer;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button replayButton;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


        replayButton.onClick.AddListener(RestartGame);
        gameOverContainer.gameObject.SetActive(false);
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void LoseLife(int currentLifeCount)
    {
        if (currentLifeCount < 0) return;

        heartImages[currentLifeCount].color = Color.gray;

        if (currentLifeCount <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        totalScoreText.text = "Total Score: " + scoreText.text;
        gameOverContainer.gameObject.SetActive(true);
        Debug.Log("GAME OVER!");
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
