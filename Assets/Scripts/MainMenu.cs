using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton, enterShopButton, exitGameButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        enterShopButton.onClick.AddListener(EnterShop);
        exitGameButton.onClick.AddListener(ExitGame);
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
