using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    //Handling a game status
    public GameObject gameOverPanel;
    public bool isGameOver;

    //Handling score
    public Text scoreText;
    public int score;

    //Handling difficulty of a game
    public int totalEnemies = 0;
    public int enemiesLeft = 0;
    [HideInInspector]
    public float gameDifficulty = 0;

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
        Instance = GetComponent<GameController>();
    }

    void Update()
    {
        if (isGameOver)
            Time.timeScale = 0;

        IncreaseDifficulty();
    }

    //Calculating game difficulty when an enemy gets killed.
    private void IncreaseDifficulty() 
    {
        gameDifficulty = (float)enemiesLeft / totalEnemies;
        minShootDelay = gameDifficulty * startMinShootDelay;
        maxShootDelay = gameDifficulty * startMaxShootDelay;
    }
}
