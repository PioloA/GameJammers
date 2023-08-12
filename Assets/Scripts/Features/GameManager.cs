using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Score")]
    [SerializeField]
    private TMP_Text scoreText;
    private int score = 0;
    private int winScore = 70;

    [Header("Timer")]
    [SerializeField]
    private TMP_Text timerText;

    [Header("Game Over")]
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private Button restartButton;
    

    
    private float gameTime = 60f;
    private float currentTime;
    private bool isGameOver = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentTime = gameTime;
        UpdateScoreText();
        UpdateTimerText();
        StartGameTimer();

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
            restartButton.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!isGameOver)
        {
            if (currentTime <= 0)
            {
                HandleGameOver();
            }
            else
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();
            }
        }
    }

    private void StartGameTimer()
    {
        StartCoroutine(CountdownTimer());
    }

    private IEnumerator CountdownTimer()
    {
        while (currentTime > 0)
        {
            yield return null;
        }
    }

    private void HandleGameOver()
    {
        isGameOver = true;
        Debug.Log("Game over! Final score: " + score);
        UpdateScoreText();
        timerText.text = "Time: 0";

        if (gameOverScreen != null) 
        {
            gameOverScreen.SetActive(true);
            if(restartButton != null)
            {
                restartButton.gameObject.SetActive(true);
            }
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreText();

        if (score >= winScore)
        {
            HandleWin();
        }
    }

    private void HandleWin()
    {
        Debug.Log("You Win!");
    }

    public void RestartGame()
    {
        score = 0;
        currentTime = gameTime;
        isGameOver = false;
        UpdateScoreText();
        UpdateTimerText();

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
            if (restartButton != null)
            {
                restartButton.gameObject.SetActive(false);
            }
        }
    }

    public void UpdateScoreText()
    {
        if (scoreText != null) 
        { 
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " +currentTime.ToString("0");
        }
    }
}
