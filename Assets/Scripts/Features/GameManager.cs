using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    public TMP_Text scoreText;
    private int score = 0;
    private int winScore = 20;

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
        UpdateScoreText();
    }

    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreText();

        if (score >= winScore)
        {
            HandleeWin();
        }
    }

    private void HandleeWin()
    {
        Debug.Log("You Win!");
    }
    public void UpdateScoreText()
    {
        if (scoreText != null) 
        { 
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
