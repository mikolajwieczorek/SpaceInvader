using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text infoText;
    public Text endScoreText;
    public Text rankingPlaceText;

    void Start()
    {
        ShowAllInformation();
    }

    private void ShowAllInformation() 
    {
        if (GameController.Instance.playerWon)
            infoText.text = "CONGRATULATIONS\nYOU WON!";
        else
            infoText.text = "YOU LOSE\nSHAME ON YOU";
        
        endScoreText.text = "Your final score:\n" + GameController.Instance.score;

        rankingPlaceText.text = "Your ranking place is: " + SaveLoadSystem.scriptInstance.SaveHighScore(GameController.Instance.score);
    }

    public void BackToMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
