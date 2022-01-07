using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    //Handling a game status
    public GameObject gameOverPanel;
    public bool playerWon;

    //Handling score
    public Text scoreText;
    public int score;

    //Handling difficulty of a game
    public int totalEnemies = 0;
    public int enemiesLeft = 0;
    [HideInInspector]
    public float gameDifficulty = 0;

    public bool isBoostActive = false;

    [HideInInspector]
    public float minShootDelay = 0;
    [HideInInspector]
    public float startMinShootDelay = 0;
    [HideInInspector]
    public float maxShootDelay = 0;
    [HideInInspector]
    public float startMaxShootDelay = 0;

    void Awake()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        Instance = GetComponent<GameController>();
    }

    void Update()
    {
        scoreText.text = score.ToString();
        IncreaseDifficulty();
    }

    public void EndTheGame(bool didYouWin) 
    {
        playerWon = didYouWin;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void IncrementScore() 
    {
        score++;
    }

    public void DecrementScore() 
    {
        score -= totalEnemies / 4;
        if (score < 0)
            score = 0;
    }

    //Calculating game difficulty when an enemy gets killed.
    private void IncreaseDifficulty() 
    {
        gameDifficulty = (float)enemiesLeft / totalEnemies;
        minShootDelay = gameDifficulty * startMinShootDelay;
        maxShootDelay = gameDifficulty * startMaxShootDelay;
    }
}
