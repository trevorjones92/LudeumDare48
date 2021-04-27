using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button startButton, enterShopButton, exitGameButton;
    public Text finalScoreText;
    public string test;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        enterShopButton.onClick.AddListener(EnterShop);
        exitGameButton.onClick.AddListener(ExitGame);
        finalScoreText.text = Obstacles.score;
    }

    void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    void EnterShop()
    {
        // Enter Shop
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
